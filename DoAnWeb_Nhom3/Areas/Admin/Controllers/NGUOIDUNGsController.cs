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
    public class NGUOIDUNGsController : Controller
    {
        private DoAnWeb_Nhom_3Entities1 db = new DoAnWeb_Nhom_3Entities1();

        // GET: Admin/NGUOIDUNGs
        public ActionResult Index()
        {
            if (Session["Admin"] == null) return RedirectToAction("Index", "Home");
            var nGUOIDUNGs = db.NGUOIDUNGs.Include(n => n.PHANQUYEN);
            return View(nGUOIDUNGs.ToList());
        }

        int LayMaND()
        {
            var maMax = db.NGUOIDUNGs.ToList().Select(n => n.MANGUOIDUNG).Max();
            return maMax + 1;
        }


        // GET: Admin/NGUOIDUNGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // GET: Admin/NGUOIDUNGs/Create
        public ActionResult Create()
        {
            if (Session["Admin"] == null) return RedirectToAction("Index", "Home");
            ViewBag.MANGUOIDUNG = LayMaND();
            ViewBag.IDQUYEN = new SelectList(db.PHANQUYENs, "IDQUYEN", "TENQUYEN");
            return View();
        }

        // POST: Admin/NGUOIDUNGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANGUOIDUNG,HOTEN,EMAIL,DIENTHOAI,MATKHAU,IDQUYEN,DIACHI")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                nGUOIDUNG.MANGUOIDUNG = LayMaND();
                db.NGUOIDUNGs.Add(nGUOIDUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDQUYEN = new SelectList(db.PHANQUYENs, "IDQUYEN", "TENQUYEN", nGUOIDUNG.IDQUYEN);
            return View(nGUOIDUNG);
        }

        // GET: Admin/NGUOIDUNGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDQUYEN = new SelectList(db.PHANQUYENs, "IDQUYEN", "TENQUYEN", nGUOIDUNG.IDQUYEN);
            return View(nGUOIDUNG);
        }

        // POST: Admin/NGUOIDUNGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANGUOIDUNG,HOTEN,EMAIL,DIENTHOAI,MATKHAU,IDQUYEN,DIACHI")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDQUYEN = new SelectList(db.PHANQUYENs, "IDQUYEN", "TENQUYEN", nGUOIDUNG.IDQUYEN);
            return View(nGUOIDUNG);
        }

        // GET: Admin/NGUOIDUNGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // POST: Admin/NGUOIDUNGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            db.NGUOIDUNGs.Remove(nGUOIDUNG);
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
        public ActionResult DangXuat()
        {
            Session["Admin"] = null;
       
            return RedirectToAction("Index", "Home");

        }
    }
}
