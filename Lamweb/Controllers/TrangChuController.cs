using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Lamweb.Models;
using PagedList;
using PagedList.Mvc;
namespace Lamweb.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        dbQLBanhangDataContext db = new dbQLBanhangDataContext();
        private List<GIAY> giaymoi(int count)
        {
            return db.GIAYs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
            var giay = giaymoi(20);
            return View(giay.ToPagedList(pageNum, pageSize));

        }
        public ActionResult Chitiet(int id)
        {
            var giay = from s in db.GIAYs where s.Magiay == id select s;
            return View(giay.Single());

        }

        public ActionResult sptheochude(int id)
        {
            var sach = from s in db.GIAYs where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult Chude()
        {
            var chude = from cd in db.CHUDEs select cd;
            return PartialView(chude);
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