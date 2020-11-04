using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lamweb.Models;
using System.Data;
using PagedList;
using PagedList.Mvc;
namespace Lamweb.Controllers
{
    public class AdminController : Controller
    {
        dbQLBanhangDataContext db = new dbQLBanhangDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if(String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Đăng nhập đang để trống";
                    }
            else if(String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Chưa nhập mật khẩu";
            }
            else
            {
                Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else ViewBag.Thongbao = "Tên đăng nhập và mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult giay(int? page)
        {
            int PageNumber = (page ?? 1);
            int PageSize = 7;

            return View(db.GIAYs.ToList().OrderBy(n => n.Magiay).ToPagedList(PageNumber, PageSize));
        }

    }
}
