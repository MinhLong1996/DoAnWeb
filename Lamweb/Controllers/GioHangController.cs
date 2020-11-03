using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lamweb.Models;

namespace Lamweb.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        dbQLBanhangDataContext db = new dbQLBanhangDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lsgiohang = Session["Giohang"] as List<Giohang>;

        if(lsgiohang==null)
            {
                lsgiohang = new List<Giohang>();
                Session["Giohang"] = lsgiohang;
            }
            return lsgiohang;
        }
public ActionResult Themgiohang(int iMagiay, string str)
{
    List<Giohang> lsgiohang = Laygiohang();
            Giohang sanpham = lsgiohang.Find(n => n.iMagiay == iMagiay);
    if (sanpham == null)
    {
        sanpham = new Giohang(iMagiay);
        lsgiohang.Add(sanpham);
        return Redirect(str);
    }
    else
    {
        sanpham.iSoluong++;
        return Redirect(str);
    }
}
private int Tongsoluong()
{
    int iTongsoluong = 0;
    List<Giohang> lsgiohang = Session["Giohang"] as List<Giohang>;
    if (lsgiohang != null)
    {
        iTongsoluong = lsgiohang.Sum(n => n.iSoluong);
    }
    return iTongsoluong;
}
private Double tongtien()
{
    double iTongtien = 0;
    List<Giohang> lsgiohang = Session["Giohang"] as List<Giohang>;
    if (lsgiohang != null)
    {
        iTongtien = lsgiohang.Sum(n => n.dThanhtien);
    }
    return iTongtien;
}
public ActionResult GioHang()
{
    List<Giohang> lsgiohang = Laygiohang();
    if (lsgiohang.Count == 0)
    {
        return RedirectToAction("Index", "TrangChu");

    }
    ViewBag.Tongsoluong = Tongsoluong();
    ViewBag.tongtien = tongtien();
    return View(lsgiohang);
}
public ActionResult Giohangpartial()
{
    ViewBag.Tongsoluong = Tongsoluong();
    ViewBag.tongtien = tongtien();
    return PartialView();
}
public ActionResult Xoagiohang(int iMaSp)
{
    List<Giohang> lsgiohang = Laygiohang();
    Giohang sanpham = lsgiohang.SingleOrDefault(n => n.iMagiay == iMaSp);
    if (sanpham != null)
    {
        lsgiohang.RemoveAll(n => n.iMagiay == iMaSp);
        return RedirectToAction("GioHang");

    }
    if (lsgiohang.Count == 0)
    {
        return RedirectToAction("Index", "TrangChu");

    }
    return RedirectToAction("GioHang");
}
public ActionResult Capnhatgiohang(int iMaSp, FormCollection f)
{
    List<Giohang> lsgiohang = Laygiohang();
    Giohang sanpham = lsgiohang.SingleOrDefault(n => n.iMagiay == iMaSp);
    if (sanpham != null)
    {
        sanpham.iSoluong = int.Parse(f["txtSoLuong"].ToString());
    }
    return RedirectToAction("GioHang");
}
public ActionResult Xoatatca()
{
    List<Giohang> lsgiohang = Laygiohang();
    lsgiohang.Clear();
    return RedirectToAction("Index", "TrangChu");
}
[HttpGet]
public ActionResult Dathang()
{
    if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
    {
        return RedirectToAction("Dangnhap", "NguoiDung");
    }
    if (Session["Giohang"] == null)
    {
        return RedirectToAction("Index", "TrangChu");
    }
    List<Giohang> lsgiohang = Laygiohang();
    ViewBag.Tongsoluong = Tongsoluong();
    ViewBag.tongtien = tongtien();
    return View(lsgiohang);
}
[HttpPost]
public ActionResult Dathang(FormCollection col)
{
    DONDATHANG ddh = new DONDATHANG();
    KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
    List<Giohang> lsgiohang = Laygiohang();
    ddh.MaKH = kh.MaKH;
    ddh.Ngaydat = DateTime.Now;
    var ngaygiao = string.Format("{0:MM/dd/yyyy}", col["Ngaygiao"]);
    ddh.Ngaygiao = DateTime.Parse(ngaygiao);
    ddh.Tinhtranggiaohang = false;
    ddh.Dathanhtoan = false;
    db.DONDATHANGs.InsertOnSubmit(ddh);
    db.SubmitChanges();
    foreach (var item in lsgiohang)
    {
        CHITIETDONTHANG ctdh = new CHITIETDONTHANG();
        ctdh.MaDonHang = ddh.MaDonHang;
        ctdh.MaGiay = item.iMagiay;
        ctdh.Soluong = item.iSoluong;
        ctdh.Dongia = (decimal)item.dDongia;
        db.CHITIETDONTHANGs.InsertOnSubmit(ctdh);
    }
    db.SubmitChanges();
    Session["Giohang"] = null;
    return RedirectToAction("Xacnhandonhang", "GioHang");
}
public ActionResult Xacnhandonhang()
{
    return View();
}
    }
}