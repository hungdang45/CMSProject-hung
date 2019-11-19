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
    public class GoodsReceiptDetailsController : Controller
    {
        private CMSEntities db = new CMSEntities();

        // GET: GoodsReceiptDetails
        public ActionResult Index()
        {
            var goodsReceiptDetails = db.GoodsReceiptDetails.Include(g => g.GoodsReceipt).Include(g => g.Product);
            return View(goodsReceiptDetails.ToList());
        }

        // GET: GoodsReceiptDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsReceiptDetail goodsReceiptDetail = db.GoodsReceiptDetails.Find(id);
            if (goodsReceiptDetail == null)
            {
                return HttpNotFound();
            }
            List<GoodsReceiptDetail> lstGoodsReceiptDetail = new List<GoodsReceiptDetail>();
            ViewBag.lstGoodsReceiptDetail = db.GoodsReceiptDetails.Where(x => x.GoodsReceiptID == id).ToList();
            return View();
            //return View(goodsReceiptDetail);
        }

        // GET: GoodsReceiptDetails/Create
        public ActionResult Create()
        {
            ViewBag.GoodsReceiptID = new SelectList(db.GoodsReceipts, "GoodsReceiptID", "GoodsReceiptName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: GoodsReceiptDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodsReceiptDetailID,GoodsReceiptID,Quantity,UnitPrice,Total,ProductID")] GoodsReceiptDetail goodsReceiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.GoodsReceiptDetails.Add(goodsReceiptDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoodsReceiptID = new SelectList(db.GoodsReceipts, "GoodsReceiptID", "GoodsReceiptName", goodsReceiptDetail.GoodsReceiptID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", goodsReceiptDetail.ProductID);
            return View(goodsReceiptDetail);
        }

        // GET: GoodsReceiptDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsReceiptDetail goodsReceiptDetail = db.GoodsReceiptDetails.Find(id);
            if (goodsReceiptDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoodsReceiptID = new SelectList(db.GoodsReceipts, "GoodsReceiptID", "GoodsReceiptName", goodsReceiptDetail.GoodsReceiptID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", goodsReceiptDetail.ProductID);
            return View(goodsReceiptDetail);
        }

        // POST: GoodsReceiptDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsReceiptDetailID,GoodsReceiptID,Quantity,UnitPrice,Total,ProductID")] GoodsReceiptDetail goodsReceiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goodsReceiptDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoodsReceiptID = new SelectList(db.GoodsReceipts, "GoodsReceiptID", "GoodsReceiptName", goodsReceiptDetail.GoodsReceiptID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", goodsReceiptDetail.ProductID);
            return View(goodsReceiptDetail);
        }

        // GET: GoodsReceiptDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsReceiptDetail goodsReceiptDetail = db.GoodsReceiptDetails.Find(id);
            if (goodsReceiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(goodsReceiptDetail);
        }

        // POST: GoodsReceiptDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoodsReceiptDetail goodsReceiptDetail = db.GoodsReceiptDetails.Find(id);
            db.GoodsReceiptDetails.Remove(goodsReceiptDetail);
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
    }
}
