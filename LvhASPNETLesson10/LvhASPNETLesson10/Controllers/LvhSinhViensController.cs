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
    public class LvhSinhViensController : Controller
    {
        private LvhK22CNT1Lesson09Entities db = new LvhK22CNT1Lesson09Entities();

        // GET: LvhSinhViens
        public ActionResult LvhIndex()
        {
            var lvhSinhViens = db.LvhSinhViens.Include(l => l.LvhKhoa);
            return View(lvhSinhViens.ToList());
        }

        // GET: LvhSinhViens/Details/5
        public ActionResult LvhDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhSinhVien lvhSinhVien = db.LvhSinhViens.Find(id);
            if (lvhSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(lvhSinhVien);
        }

        // GET: LvhSinhViens/Create
        public ActionResult LvhCreate()
        {
            ViewBag.LvhMaKH = new SelectList(db.LvhKhoas, "LvhMaKH", "LvhTenKH");
            return View();
        }

        // POST: LvhSinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhCreate([Bind(Include = "LvhMaSV,LvhHoSV,LvhTenSV,LvhPhai,LvhNgaySinh,LvhNoiSinh,LvhMaKH,LvhHocBong,LvhDiemTrungBinh")] LvhSinhVien lvhSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.LvhSinhViens.Add(lvhSinhVien);
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }

            ViewBag.LvhMaKH = new SelectList(db.LvhKhoas, "LvhMaKH", "LvhTenKH", lvhSinhVien.LvhMaKH);
            return View(lvhSinhVien);
        }

        // GET: LvhSinhViens/Edit/5
        public ActionResult LvhEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhSinhVien lvhSinhVien = db.LvhSinhViens.Find(id);
            if (lvhSinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.LvhMaKH = new SelectList(db.LvhKhoas, "LvhMaKH", "LvhTenKH", lvhSinhVien.LvhMaKH);
            return View(lvhSinhVien);
        }

        // POST: LvhSinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhEdit([Bind(Include = "LvhMaSV,LvhHoSV,LvhTenSV,LvhPhai,LvhNgaySinh,LvhNoiSinh,LvhMaKH,LvhHocBong,LvhDiemTrungBinh")] LvhSinhVien lvhSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lvhSinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }
            ViewBag.LvhMaKH = new SelectList(db.LvhKhoas, "LvhMaKH", "LvhTenKH", lvhSinhVien.LvhMaKH);
            return View(lvhSinhVien);
        }

        // GET: LvhSinhViens/Delete/5
        public ActionResult LvhDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhSinhVien lvhSinhVien = db.LvhSinhViens.Find(id);
            if (lvhSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(lvhSinhVien);
        }

        // POST: LvhSinhViens/Delete/5
        [HttpPost, ActionName("LvhDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LvhSinhVien lvhSinhVien = db.LvhSinhViens.Find(id);
            db.LvhSinhViens.Remove(lvhSinhVien);
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
