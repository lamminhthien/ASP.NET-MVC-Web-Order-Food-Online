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
    public class DanhMucController : Controller
    {
        DoAnWeb_Nhom_3Entities1 db = new DoAnWeb_Nhom_3Entities1();

        public ActionResult DanhmucPartial()
        {
            var danhmuc = db.LOAISANPHAMs.ToList();
            return PartialView(danhmuc);
        }
    }
}
