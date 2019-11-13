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

        // GET: GoodsReceipts
        //public ActionResult Index()
        //{
        //    var goodsReceipts = db.GoodsReceipts.Include(g => g.Supplier);
        //    return View(goodsReceipts.ToList());
        //}
        public ActionResult Index(int? id)
        {
            TempData["idSupplier"] = id;
            var goodsReceipts = db.GoodsReceipts.Where(n=>n.SupplierID==id);
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
            int idSupplier = Int32.Parse(TempData["idSupplier"].ToString());
            CMSEntities db = new CMSEntities();
            if (ModelState.IsValid)
            {
                goodsReceipt.SupplierID = idSupplier;
                goodsReceipt.AddedDate = DateTime.Now;
                db.GoodsReceipts.Add(goodsReceipt);
                db.SaveChanges();
                return RedirectToAction("Index/" + idSupplier);
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
    }
}
