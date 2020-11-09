using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lamweb.Models;
using System.Data;
using PagedList;
using PagedList.Mvc;
using System.IO;
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
        [HttpGet]
        public ActionResult Xoasanpham(int id)
        {
            GIAY giay = db.GIAYs.SingleOrDefault(n => n.Magiay == id);
            ViewBag.Magiay = giay.Magiay;
            if (giay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(giay);
        }
        [HttpPost,ActionName("XoaSP")]
        public ActionResult Xacnhanxoa(int id)
        {
            GIAY giay = db.GIAYs.SingleOrDefault(n => n.Magiay == id);
            ViewBag.Magiay = giay.Magiay;
            if (giay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.GIAYs.DeleteOnSubmit(giay);
            db.SubmitChanges();
            return RedirectToAction("giay");

        }
        public ActionResult ThemmoiSP()
        {
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChude");
            ViewBag.MaNPP = new SelectList(db.NHAPHANPHOIs.ToList().OrderBy(n => n.TenNPP), "MaNPP", "TenNPP");
            return View();
        }
        [HttpPost]
        public ActionResult ThemmoiSP(GIAY giay, HttpPostedFileBase fileupload)
        {
            var filename = Path.GetFileName(fileupload.FileName);
            var path = Path.Combine(Server.MapPath("~/imagers/"), filename);
            if (System.IO.File.Exists(path))
            {
                ViewBag.Thongbao = "Hinh ảnh đã tồn tại";
            }
            else
            { fileupload.SaveAs(path); }
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChude");
            ViewBag.MaNPP = new SelectList(db.NHAPHANPHOIs.ToList().OrderBy(n => n.TenNPP), "MaCD", "TenChude");
            return View();

        }
        public ActionResult ChitietSP(int id)
        {
            GIAY giay = db.GIAYs.SingleOrDefault(n => n.Magiay == id);
            ViewBag.Magiay = giay.Magiay;   
            if(giay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(giay);
                
        }
        [HttpGet]
        public ActionResult SuaSP(int id)
        {
            GIAY giay = db.GIAYs.SingleOrDefault(n => n.Magiay == id);
            
            if (giay == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(giay);
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChude",giay.MaCD);
            ViewBag.MaNPP = new SelectList(db.NHAPHANPHOIs.ToList().OrderBy(n => n.TenNPP), "MaNPP", "TenNPP",giay.MaNPP);
            return View(giay);

        }

        public ActionResult giay(int? page)
        {
            int PageNumber = (page ?? 1);
            int PageSize = 7;

            return View(db.GIAYs.ToList().OrderBy(n => n.Magiay).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult nguoidung(int? page)
        {
            int PageNumber = (page ?? 1);
            int PageSize = 7;

            return View(db.KHACHHANGs.ToList().OrderBy(n => n.MaKH).ToPagedList(PageNumber, PageSize));
        }





        //Thêm xóa chỉnh sửa người dùng
        [HttpGet]
        public ActionResult XoaND(int id)
        {
            KHACHHANG nguoidung = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == id);
            ViewBag.MaKH = nguoidung.MaKH;
            if (nguoidung == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nguoidung);
        }
        [HttpPost, ActionName("XoaND")]
        public ActionResult XacnhanxoaND(int id)
        {
            KHACHHANG nguoidung = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == id);
            ViewBag.MaKH = nguoidung.MaKH;
            if (nguoidung == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KHACHHANGs.DeleteOnSubmit(nguoidung);
            db.SubmitChanges();
            return RedirectToAction("nguoidung");

        }
  
    }
}
