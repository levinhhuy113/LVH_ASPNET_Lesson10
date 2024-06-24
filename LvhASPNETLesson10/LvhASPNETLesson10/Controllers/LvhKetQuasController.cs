using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LvhASPNETLesson10.Models;

namespace LvhASPNETLesson10.Controllers
{
    public class LvhKetQuasController : Controller
    {
        private LvhK22CNT1Lesson09Entities db = new LvhK22CNT1Lesson09Entities();

        // GET: LvhKetQuas
        public ActionResult LvhIndex()
        {
            var lvhKetQuas = db.LvhKetQuas.Include(l => l.LvhMonHoc).Include(l => l.LvhSinhVien);
            return View(lvhKetQuas.ToList());
        }

        // GET: LvhKetQuas/Details/5
        public ActionResult LvhDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhKetQua lvhKetQua = db.LvhKetQuas.Find(id);
            if (lvhKetQua == null)
            {
                return HttpNotFound();
            }
            return View(lvhKetQua);
        }

        // GET: LvhKetQuas/Create
        public ActionResult LvhCreate()
        {
            ViewBag.LvhMaMH = new SelectList(db.LvhMonHocs, "LvhMaMH", "LvhTenMH");
            ViewBag.LvhMaSV = new SelectList(db.LvhSinhViens, "LvhMaSV", "LvhHoSV");
            return View();
        }

        // POST: LvhKetQuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhCreate([Bind(Include = "LvhMaSV,LvhMaMH,LvhDiem")] LvhKetQua lvhKetQua)
        {
            if (ModelState.IsValid)
            {
                db.LvhKetQuas.Add(lvhKetQua);
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }

            ViewBag.LvhMaMH = new SelectList(db.LvhMonHocs, "LvhMaMH", "LvhTenMH", lvhKetQua.LvhMaMH);
            ViewBag.LvhMaSV = new SelectList(db.LvhSinhViens, "LvhMaSV", "LvhHoSV", lvhKetQua.LvhMaSV);
            return View(lvhKetQua);
        }

        // GET: LvhKetQuas/Edit/5
        public ActionResult LvhEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhKetQua lvhKetQua = db.LvhKetQuas.Find(id);
            if (lvhKetQua == null)
            {
                return HttpNotFound();
            }
            ViewBag.LvhMaMH = new SelectList(db.LvhMonHocs, "LvhMaMH", "LvhTenMH", lvhKetQua.LvhMaMH);
            ViewBag.LvhMaSV = new SelectList(db.LvhSinhViens, "LvhMaSV", "LvhHoSV", lvhKetQua.LvhMaSV);
            return View(lvhKetQua);
        }

        // POST: LvhKetQuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhEdit([Bind(Include = "LvhMaSV,LvhMaMH,LvhDiem")] LvhKetQua lvhKetQua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lvhKetQua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }
            ViewBag.LvhMaMH = new SelectList(db.LvhMonHocs, "LvhMaMH", "LvhTenMH", lvhKetQua.LvhMaMH);
            ViewBag.LvhMaSV = new SelectList(db.LvhSinhViens, "LvhMaSV", "LvhHoSV", lvhKetQua.LvhMaSV);
            return View(lvhKetQua);
        }

        // GET: LvhKetQuas/Delete/5
        public ActionResult LvhDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhKetQua lvhKetQua = db.LvhKetQuas.Find(id);
            if (lvhKetQua == null)
            {
                return HttpNotFound();
            }
            return View(lvhKetQua);
        }

        // POST: LvhKetQuas/Delete/5
        [HttpPost, ActionName("LvhDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LvhDeleteConfirmed(string id)
        {
            LvhKetQua lvhKetQua = db.LvhKetQuas.Find(id);
            db.LvhKetQuas.Remove(lvhKetQua);
            db.SaveChanges();
            return RedirectToAction("LvhIndex");
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
