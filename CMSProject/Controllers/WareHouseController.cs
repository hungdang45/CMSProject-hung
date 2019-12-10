using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSProject.Models;
using PagedList;

namespace CMSProject.Controllers
{
    public class WareHouseController : Controller
    {
        private CMSEntities db = new CMSEntities();
        // GET: WareHouse
        public ActionResult Index()
        {
            return View();
        }
        //public PartialViewResult _Index(int? page)
        //{
        //    int pageNumber = page ?? 1;
        //    int pageSize = 10;
        //    var model = db.Products.OrderBy(n => n.ProductID).ToPagedList(pageNumber, pageSize);
        //    return PartialView(model);
        //}

        public ActionResult _Index(int? page, string productName)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var result = from p in db.Products
                         select p;
            if (!String.IsNullOrEmpty(productName))
            {
                result = result.Where(n => n.ProductName.Contains(productName));
            }
            ViewBag.productName = productName;
            return PartialView(result.OrderBy(n => n.ProductID).ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult _Index(int? page, string productName, int pageNumber, int pageSize)
        {
            var result = from p in db.Products
                         select p;
            if (!String.IsNullOrEmpty(productName))
            {
                result = result.Where(n => n.ProductName.Contains(productName));
            }
            ViewBag.productName = productName;
            return View(result.OrderBy(n => n.ProductID).ToPagedList(pageNumber, pageSize));
        }


    }
}