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
        public PartialViewResult _Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var model = db.Products.OrderBy(n => n.ProductID).ToPagedList(pageNumber, pageSize);
            return PartialView(model);
        }
    }
}