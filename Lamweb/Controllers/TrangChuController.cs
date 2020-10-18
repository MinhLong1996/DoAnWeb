using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lamweb.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Chitiet()
        {
            return View();
        }
        public ActionResult Lienhe()
        {
            return View();
        }
        public ActionResult Quangcao()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
    }
}