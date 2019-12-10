using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSProject.Models;
using PagedList;

namespace CMSProject.Controllers
{
    public class SuppliersController : Controller
    {
        private CMSEntities db = new CMSEntities();

        // GET: Suppliers
        public ActionResult Index()
        {
            //return View(db.Suppliers.ToList());
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            else
            {
                int checkRoles = Convert.ToInt32(Session["Roles"]);
                if (checkRoles == 1)
                {
                    return View(db.Suppliers.ToList());
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        public ActionResult _Index(int? page, string supplierName)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var result = from p in db.Suppliers
                         select p;
            if (!String.IsNullOrEmpty(supplierName))
            {
                result = result.Where(n => n.SupplierName.Contains(supplierName));
            }
            ViewBag.supplierName = supplierName;
            return PartialView(result.OrderBy(n => n.SupplierID).ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult _Index(int? page, string supplierName, int pageNumber, int pageSize)
        {
            var result = from p in db.Suppliers
                         select p;
            if (!String.IsNullOrEmpty(supplierName))
            {
                result = result.Where(n => n.SupplierName.Contains(supplierName));
            }
            ViewBag.supplierName = supplierName;
            return View(result.OrderBy(n => n.SupplierID).ToPagedList(pageNumber, pageSize));
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,OtherDetails,ContactAddress,ContactEmail,ContactPhone")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,OtherDetails,ContactAddress,ContactEmail,ContactPhone")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
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
