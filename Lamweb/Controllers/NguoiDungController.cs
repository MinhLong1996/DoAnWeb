using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lamweb.Models;
namespace Lamweb.Controllers
{
    public class NguoiDungController : Controller
    {
        dbQLBanhangDataContext db = new dbQLBanhangDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KHACHHANG kh)
        {
            var hoten = collection["hotenkh"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["matkhaunhaplai"];
            var sdt = collection["dienthoai"];
            var diachi = collection["diachi"];
            var email = collection["email"];
            var ngaysinh = string.Format("{0:MM/dd/YYYY}", collection["Ngaysinh"]);
            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["loi1"] = "Họ tên khách hàng không được bỏ trống";
            }
            else if (string.IsNullOrEmpty(tendn))
            {
                ViewData["loi2"] = "phải nhập tên đăng nhập";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["loi3"] = "mật khẩu không được bỏ trống";
            }
            else if (string.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["loi4"] = "nhập lại mật khẩu";
            }
            if (string.IsNullOrEmpty(sdt))
            {
                ViewData["loi5"] = "số điện thoại không được bỏ trống";
            }
            if (string.IsNullOrEmpty(email))
            {
                ViewData["loi6"] = "email không được bỏ trống";
            }
            if (string.IsNullOrEmpty(diachi))
            {
                ViewData["loi7"] = "Địa chỉ không được bỏ trống";
            }
            else
            {
                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.DiachiKH = diachi;
                kh.DienthoaiKH = sdt;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Dangky();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {

            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["loi1"] = "phải nhập tên đăng nhập";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["loi2"] = "phải nhập mật khẩu";
            }
            else
            {
                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
                Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Chúc mwungf đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    return RedirectToAction("Index", "TrangChu");

                }
                else if (ad != null)
                {
                     ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return PartialView();

        }


    }
}