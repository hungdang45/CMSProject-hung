using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSProject.Controllers
{
    public class ChinhsachClientController : Controller
    {
        // GET: ChinhsachClient
        public ActionResult ChinhSachDoiHang()
        {
            return View();
        }
        public ActionResult ChinhSachBaoMat()
        {
            return View();
        }
        public ActionResult ChinhSachTraHang()
        {
            return View();
        }
        public ActionResult ChinhSachBaoHanh()
        {
            return View();
        }
    }
}