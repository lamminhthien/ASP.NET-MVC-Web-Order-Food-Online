using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnWeb_Nhom3.Models;

namespace DoAnWeb_Nhom3.Controllers
{
    public class SANPHAMsController : Controller
    {
        DoAnWeb_Nhom_3Entities1 db = new DoAnWeb_Nhom_3Entities1();
        public ActionResult sanPhamCungLoai(string id_loaisp)
        {
            int id = Int32.Parse(id_loaisp);
            var ds_sp = db.SANPHAMs.Where(n => n.MALOAISP == id).ToList();
            return PartialView(ds_sp);
        }
        public ActionResult doAn()
        {
            var dA = db.SANPHAMs.Where(n => n.MALOAISP == 2).Take(4).ToList();
            return PartialView(dA);
        }
        public ActionResult doUong()
        {
            var doUong = db.SANPHAMs.Where(n => n.MALOAISP == 1).Take(4).ToList();
            return PartialView(doUong);
        }

        //public ActionResult dttheohang()
        //{
        //    var mi = db.Sanphams.Where(n => n.Mahang == 5).Take(4).ToList();
        //    return PartialView(mi);
        //}
        public ActionResult xemchitiet(int MASP = 0)
        {
            var chitiet = db.SANPHAMs.SingleOrDefault(n => n.MASP == MASP);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }
        [HttpGet]
        public ActionResult search_byname(string tukhoa = "")
        {
            var tk_ten = db.SANPHAMs.Where(n => n.TENSP.Contains(tukhoa));
            return View(tk_ten);


        }
    }
}
