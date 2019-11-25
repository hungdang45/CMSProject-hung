using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSProject.Models;

namespace CMSProject.Controllers
{
    public class GrossController : Controller
    {
        private CMSEntities db = new CMSEntities();
        // GET: Gross
        public ActionResult Index()
        {
            var data = db.spud_DoanhThuSPTheoThang(null, null).ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Index(int? Thang, int? Nam)
        {
            //var month = db.orders.Where(n => n.status == 2 && n.createDate.Value.Day == 6).ToList();
            //var totalMonth = month.Sum(n => n.total);
            ViewBag.Thang = Thang;
            ViewBag.Nam = Nam;
            var data = db.spud_DoanhThuSPTheoThang(Thang, Nam).ToList();
            return View(data);
        }
    }
}