using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnWeb_Nhom3.Models;

namespace DoAnWeb_Nhom3.Areas.Admin.Controllers
{
    public class SANPHAMsController : Controller
    {
        private DoAnWeb_Nhom_3Entities1 db = new DoAnWeb_Nhom_3Entities1();
        int LayMaSP()
        {
            var maMax = db.SANPHAMs.ToList().Select(n => n.MASP).Max();
            return maMax+1;
        }


        // GET: Admin/SANPHAMs
        public ActionResult Index()
        {
            if (Session["Admin"] == null) return RedirectToAction("Index", "SANPHAMs");
            var sANPHAMs = db.SANPHAMs.Include(s => s.LOAISANPHAM);
            return View(sANPHAMs.ToList());
        }

        // GET: Admin/SANPHAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAMs/Create
        public ActionResult Create()
        {
            if (Session["Admin"] == null) return RedirectToAction("Index", "SANPHAMs");
            ViewBag.MASP = LayMaSP();
            ViewBag.MALOAISP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP");
            return View();
        }

        // POST: Admin/SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASP,TENSP,GIATIEN,SOLUONG,MOTA,ANHBIA,MALOAISP")] SANPHAM sANPHAM)
        {
            var imgSP = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgSP.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSP.SaveAs(path);
            if (ModelState.IsValid)
            {
                sANPHAM.MASP = LayMaSP();
                sANPHAM.ANHBIA = postedFileName;
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MALOAISP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP", sANPHAM.MALOAISP);
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALOAISP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP", sANPHAM.MALOAISP);
            return View(sANPHAM);
        }

        // POST: Admin/SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASP,TENSP,GIATIEN,SOLUONG,MOTA,ANHBIA,MALOAISP")] SANPHAM sANPHAM)
        {
            var imgSP = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgSP.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSP.SaveAs(path);

            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                sANPHAM.ANHBIA = postedFileName;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MALOAISP = new SelectList(db.LOAISANPHAMs, "MALOAISP", "TENLOAISP", sANPHAM.MALOAISP);
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: Admin/SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
