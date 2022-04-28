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
    public class LOAISANPHAMsController : Controller
    {
        private DoAnWeb_Nhom_3Entities1 db = new DoAnWeb_Nhom_3Entities1();

        // GET: Admin/LOAISANPHAMs
        public ActionResult Index()
        {
            if (Session["Admin"] == null) return RedirectToAction("Index", "Home");
            return View(db.LOAISANPHAMs.ToList());
        }

        int LayMaLSP()
        {
            var maMax = db.LOAISANPHAMs.ToList().Select(n => n.MALOAISP).Max();
            return maMax + 1;
        }

        // GET: Admin/LOAISANPHAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            if (lOAISANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAISANPHAM);
        }

        // GET: Admin/LOAISANPHAMs/Create
        public ActionResult Create()
        {
            if (Session["Admin"] == null) return RedirectToAction("Index", "Home");
            ViewBag.MALOAISP = LayMaLSP();
            return View();
        }

        // POST: Admin/LOAISANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOAISP,TENLOAISP")] LOAISANPHAM lOAISANPHAM)
        {
            if (ModelState.IsValid)
            {
                lOAISANPHAM.MALOAISP = LayMaLSP();
                db.LOAISANPHAMs.Add(lOAISANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAISANPHAM);
        }

        // GET: Admin/LOAISANPHAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            if (lOAISANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAISANPHAM);
        }

        // POST: Admin/LOAISANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOAISP,TENLOAISP")] LOAISANPHAM lOAISANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAISANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAISANPHAM);
        }

        // GET: Admin/LOAISANPHAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            if (lOAISANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAISANPHAM);
        }

        // POST: Admin/LOAISANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            db.LOAISANPHAMs.Remove(lOAISANPHAM);
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
