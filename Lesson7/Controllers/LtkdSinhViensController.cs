using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lesson7.Models;

namespace Lesson7.Controllers
{
    public class LtkdSinhViensController : Controller
    {
        private LtkdK22CNT3Lesson7DbEntities db = new LtkdK22CNT3Lesson7DbEntities();

        // GET: LtkdSinhViens
        public ActionResult LtkdIndex()
        {
            return View(db.LtkdSinhVien.ToList());
        }

        // GET: LtkdSinhViens/Details/5
        public ActionResult LtkdDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LtkdSinhVien ltkdSinhVien = db.LtkdSinhVien.Find(id);
            if (ltkdSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(ltkdSinhVien);
        }

        // GET: LtkdSinhViens/Create
        public ActionResult LtkdCreate()
        {
            return View();
        }

        // POST: LtkdSinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LtkdCreate([Bind(Include = "LtkdMaSV,LtkdHoSV,LtkdTenSV,LtkdNgaySinh,LtkdPhai,LtkdPhone,LtkdEmail,LtkdMaKH")] LtkdSinhVien ltkdSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.LtkdSinhVien.Add(ltkdSinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ltkdSinhVien);
        }

        // GET: LtkdSinhViens/Edit/5
        public ActionResult LtkdEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LtkdSinhVien ltkdSinhVien = db.LtkdSinhVien.Find(id);
            if (ltkdSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(ltkdSinhVien);
        }

        // POST: LtkdSinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LtkdEdit([Bind(Include = "LtkdMaSV,LtkdHoSV,LtkdTenSV,LtkdNgaySinh,LtkdPhai,LtkdPhone,LtkdEmail,LtkdMaKH")] LtkdSinhVien ltkdSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ltkdSinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ltkdSinhVien);
        }

        // GET: LtkdSinhViens/Delete/5
        public ActionResult LtkdDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LtkdSinhVien ltkdSinhVien = db.LtkdSinhVien.Find(id);
            if (ltkdSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(ltkdSinhVien);
        }

        // POST: LtkdSinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult LtkdDeleteConfirmed(string id)
        {
            LtkdSinhVien ltkdSinhVien = db.LtkdSinhVien.Find(id);
            db.LtkdSinhVien.Remove(ltkdSinhVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void LtkdDispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
