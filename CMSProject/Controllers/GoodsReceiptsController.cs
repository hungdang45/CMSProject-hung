using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSProject.Models;

namespace CMSProject.Controllers
{
    public class GoodsReceiptsController : Controller
    {
        private CMSEntities db = new CMSEntities();
        List<Storage> LstStorage = new List<Storage>(); //Khởi tạo Class Storage lên

        // GET: GoodsReceipts
        //public ActionResult Index()
        //{
        //    var goodsReceipts = db.GoodsReceipts.Include(g => g.Supplier);
        //    return View(goodsReceipts.ToList());
        //}
        public ActionResult Index()
        {
            var goodsReceipts = db.GoodsReceipts;
            return View(goodsReceipts.ToList());
        }

        // GET: GoodsReceipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsReceipt goodsReceipt = db.GoodsReceipts.Find(id);
            //Viết ViewBag tại đây
            if (goodsReceipt == null)
            {
                return HttpNotFound();
            }
            return View(goodsReceipt);
        }

        // GET: GoodsReceipts/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            return View();
        }

        // POST: GoodsReceipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodsReceiptID,SupplierID,GoodsReceiptName,AddedDate,Creator,Status,Total")] GoodsReceipt goodsReceipt)
        {
            CMSEntities db = new CMSEntities();
            if (ModelState.IsValid)
            {
                goodsReceipt.AddedDate = DateTime.Now;
                db.GoodsReceipts.Add(goodsReceipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", goodsReceipt.SupplierID);
            return View(goodsReceipt);
        }

        // GET: GoodsReceipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsReceipt goodsReceipt = db.GoodsReceipts.Find(id);
            if (goodsReceipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", goodsReceipt.SupplierID);
            return View(goodsReceipt);
        }

        // POST: GoodsReceipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsReceiptID,SupplierID,GoodsReceiptName,AddedDate,Creator,Status,Total")] GoodsReceipt goodsReceipt)
        {
            int idSupplier = Int32.Parse(TempData["idSupplier"].ToString());
            if (ModelState.IsValid)
            {
                goodsReceipt.AddedDate = DateTime.Now;
                db.Entry(goodsReceipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index/" + idSupplier);
            }
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", goodsReceipt.SupplierID);
            return View(goodsReceipt);
        }

        // GET: GoodsReceipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsReceipt goodsReceipt = db.GoodsReceipts.Find(id);
            if (goodsReceipt == null)
            {
                return HttpNotFound();
            }
            return View(goodsReceipt);
        }

        // POST: GoodsReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoodsReceipt goodsReceipt = db.GoodsReceipts.Find(id);
            db.GoodsReceipts.Remove(goodsReceipt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Debug Button "Them vao"
        public ActionResult AddGoodsReceipt(int id)
        {
            if (Session["Storage"] != null)
            {
                LstStorage = Session["Storage"] as List<Storage>;
            }
            var lstGoodsReceipt = LstStorage.Where(n => n.GoodsReceiptID == id).ToList();
            if (lstGoodsReceipt.Count > 0)
            {
                TempData["TotalGoodsReceipt"] = lstGoodsReceipt.Sum(n => n.Total);
            }
            else
            {
                TempData["TotalGoodsReceipt"] = 0;
            }
            GoodsReceipt goodsReceipt = db.GoodsReceipts.Find(id);
            ViewBag.totalGoodsReceiptDetail = TempData["TotalGoodsReceipt"];
            TempData["idGoodsReceipt"] = id;
            return View(goodsReceipt);
        }

        //Show ra danh sách product
        public ActionResult LstPro(int id)
        {
            ViewBag.idGoodsReceipt = TempData["idGoodsReceipt"];
            var dataPro = db.Products.ToList();
            return View(dataPro);
        }

        public ActionResult LstGoodsReceipt()
        {
            if (Session["Storage"] == null)
            {
                LstStorage = new List<Storage>();
            }
            else
            {
                LstStorage = Session["Storage"] as List<Storage>;
            }
            int idStorage = Int32.Parse(TempData["idGoodsReceipt"].ToString());
            var dataStorage = LstStorage.Where(n => n.GoodsReceiptID == idStorage).ToList();
            return View(dataStorage);
        }

        //Xử lý chức năng thêm sản phẩm vào LstGoodsReceipt
        [HttpPost]
        public ActionResult LstGoodsReceipt(int? id, int? idGoodsReceipt)
        {
            //Khởi tạo flag nếu bằng false thì cho phép thêm mới còn ngược lại thì sẽ cập nhật số lượng
            bool flag = false;
            if (Session["Storage"] == null)
            {
                LstStorage = new List<Storage>();
            }
            else
            {
                LstStorage = Session["Storage"] as List<Storage>;
                //Khởi tạo biến danh sách ở tại cái phiếu nhập ấy để chỉ tăng số lượng ở trong danh sách phiếu nhập này
                var lstGoodsReceipt = LstStorage.Where(n => n.GoodsReceiptID == idGoodsReceipt).ToList();
                foreach (var item in lstGoodsReceipt)
                {
                    //Kiểm tra nếu như đã tồn tại cái id sản phẩm rồi thì nó sẽ update số lượng tăng thêm 1 sau mỗi lần click
                    if (item.ProductID == id)
                    {
                        flag = true;
                        item.Quantity += 1;
                        break;
                    }
                }
            }
            Product product = db.Products.Where(n => n.ProductID == id).FirstOrDefault();
            int idGoods_receipt = idGoodsReceipt.Value;
            if (flag == false)
            {
                Storage storage = new Storage();
                storage.ProductID = id.Value;
                storage.GoodsReceiptID = idGoods_receipt;
                storage.ProductName = product.ProductName;
                storage.Quantity = 1;
                storage.Total = storage.Quantity * storage.UnitPrice;
                LstStorage.Add(storage);
            }
            Session["Storage"] = LstStorage;
            return RedirectToAction("AddGoodsReceipt/" + idGoods_receipt);
        }

        //Cập nhật số lượng và đơn giá
        [HttpPost]
        public ActionResult updateQuantityAndUnitPrice(int id, int? idGoodsReceipt, int quantitied, int Priced, int unitPriced)
        {
            if (Session["Storage"] == null)
            {
                LstStorage = new List<Storage>();
            }
            else
            {
                LstStorage = Session["Storage"] as List<Storage>;
            }
            var lstGoodsReceipt = LstStorage.Where(n => n.GoodsReceiptID == idGoodsReceipt).ToList();
            if (lstGoodsReceipt != null)
            {
                lstGoodsReceipt.Where(n => n.ProductID == id).FirstOrDefault().Quantity = quantitied;
                lstGoodsReceipt.Where(n => n.ProductID == id).FirstOrDefault().UnitPrice = unitPriced;
                lstGoodsReceipt.Where(n => n.ProductID == id).FirstOrDefault().Price = Priced;
                lstGoodsReceipt.Where(n => n.ProductID == id).FirstOrDefault().Total = quantitied * unitPriced;
            }
            else
            {
                return null;
            }
            int idGoods_receipt = idGoodsReceipt.Value;
            Session["Storage"] = LstStorage;
            return RedirectToAction("AddGoodsReceipt/" + idGoods_receipt);
        }

        //Xóa sản phẩm tại thời điểm click xóa trong lstGoodsReceipt
        [HttpPost]
        public ActionResult RemoveProduct(int id, int? idGoodsReceipt)
        {
            if (Session["Storage"] != null)
            {
                LstStorage = Session["Storage"] as List<Storage>;
            }
            if (LstStorage != null)
            {
                var pro = LstStorage.Where(n => n.ProductID == id).FirstOrDefault();
                LstStorage.Remove(pro);
            }
            int idGoods_receipt = idGoodsReceipt.Value;
            return RedirectToAction("AddGoodsReceipt/" + idGoods_receipt);
        }

        //Lưu phiếu vào db
        public ActionResult SaveGoodsReceiptToDb(int id)
        {
            if (Session["Storage"] != null)
            {
                LstStorage = Session["Storage"] as List<Storage>;
            }
            var lstGoodsReceipt = LstStorage.Where(n => n.GoodsReceiptID == id).ToList();
            foreach (var item in lstGoodsReceipt)
            {
                GoodsReceiptDetail goodsReceiptDetail = new GoodsReceiptDetail();
                goodsReceiptDetail.GoodsReceiptID = item.GoodsReceiptID;
                goodsReceiptDetail.ProductID = item.ProductID;
                goodsReceiptDetail.Quantity = item.Quantity;
                goodsReceiptDetail.UnitPrice = item.UnitPrice;
                goodsReceiptDetail.Total = item.Total;
                db.GoodsReceiptDetails.Add(goodsReceiptDetail);
                db.SaveChanges();
                //Cập nhật số lượng và giá bán cho product
                var pro = db.Products.Where(n => n.ProductID == item.ProductID).FirstOrDefault();
                pro.UpdateBy = "Hung Dang";
                pro.Quantity += item.Quantity;
                pro.Price = item.Price;
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
            }
            if (lstGoodsReceipt.Count > 0)
            {
                TempData["TotalGoodsReceipt"] = lstGoodsReceipt.Sum(n => n.Total);
            }
            else
            {
                TempData["TotalGoodsReceipt"] = 0;
            }
            GoodsReceipt goodsReceipt = db.GoodsReceipts.Where(n => n.GoodsReceiptID == id).FirstOrDefault();
            goodsReceipt.AddedDate = DateTime.Now;
            goodsReceipt.Total = Convert.ToDecimal(TempData["TotalGoodsReceipt"]);
            db.Entry(goodsReceipt).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
