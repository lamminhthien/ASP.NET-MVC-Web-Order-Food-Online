using DoAnWeb_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DoAnWeb_Nhom3.Controllers
{
    public class LichSuMuaHangController : Controller
    {
        // GET: LichSuMuaHang
            DoAnWeb_Nhom_3Entities1 db = new DoAnWeb_Nhom_3Entities1();
            // GET: Admin/LichSuMuaHang
            public ActionResult Index()
            {
            var u = Session["use"] as DoAnWeb_Nhom3.Models.NGUOIDUNG;
            var history = from a in db.NGUOIDUNGs
                          join b in db.DONDATHANGs
                          on a.MANGUOIDUNG equals b.MANGUOIDUNG
                          join c in db.CHITIETDHs
                          on b.MADON equals c.MADON
                          join d in db.SANPHAMs
                          on c.MASP equals d.MASP
                          where a.MANGUOIDUNG == u.MANGUOIDUNG
                              select new LichSuMuaHang()
                              {
                                  TenKH = a.HOTEN,
                                  TenSP = d.TENSP,
                                  NgayDat = (DateTime)b.NGAYDAT,
                                  SoLuong = (int)c.SOLUONG,
                                  DonGia = d.GIATIEN

                              };

                return View(history.ToList());
            }
    }
}