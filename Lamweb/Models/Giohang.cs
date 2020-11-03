using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lamweb.Models
{
    public class Giohang
    {
        dbQLBanhangDataContext db = new dbQLBanhangDataContext();
        public int iMagiay { set; get; }
        public string sTengiay { set; get; }
        public string sAnhbia { set; get; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }

        }
        public Giohang(int Masach)
        {
            iMagiay = Masach;
            GIAY giay = db.GIAYs.Single(n => n.Magiay == iMagiay);
            sTengiay = giay.Tengiay;
            sAnhbia = giay.Anhbia;
            dDongia = Double.Parse(giay.Giaban.ToString());
            iSoluong = 1;
        }
    }
}