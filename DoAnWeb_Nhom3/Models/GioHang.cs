using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnWeb_Nhom3.Models
{
    public class GioHang
    {
        //private int iMaSP;

        //public int IMaSP
        //{
        //    get { return iMaSP; }
        //    set { iMaSP = value; }
        //}
        DoAnWeb_Nhom_3Entities1 db = new DoAnWeb_Nhom_3Entities1();
        public int iMASP { get; set; }
        public string sTENSP { get; set; }
        public string sANHBIA { get; set; }
        public double dDONGIA { get; set; }
        public int iSOLUONG { get; set; }
        public double THANHTIEN
        {
            get { return iSOLUONG * dDONGIA; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int MASP)
        {
            iMASP = MASP;
            SANPHAM sp = db.SANPHAMs.Single(n => n.MASP == iMASP);
            sTENSP = sp.TENSP;
            sANHBIA = sp.ANHBIA;
            dDONGIA = double.Parse(sp.GIATIEN.ToString());
            iSOLUONG = 1;
        }
    }
}