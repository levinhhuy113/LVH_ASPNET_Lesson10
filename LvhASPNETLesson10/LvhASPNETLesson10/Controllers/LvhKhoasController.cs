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
    public class LvhKhoasController : Controller
    {
        private LvhK22CNT1Lesson09Entities db = new LvhK22CNT1Lesson09Entities();

        // GET: LvhKhoas
        public ActionResult LvhIndex()
        {
            return View(db.LvhKhoas.ToList());
        }

        // GET: LvhKhoas/Details/5
        public ActionResult LvhDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhKhoa lvhKhoa = db.LvhKhoas.Find(id);
            if (lvhKhoa == null)
            {
                return HttpNotFound();
            }
            return View(lvhKhoa);
        }

        // GET: LvhKhoas/Create
        public ActionResult LvhCreate()
        {
            return View();
        }

        // POST: LvhKhoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhCreate([Bind(Include = "LvhMaKH,LvhTenKH")] LvhKhoa lvhKhoa)
        {
            if (ModelState.IsValid)
            {
                db.LvhKhoas.Add(lvhKhoa);
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }

            return View(lvhKhoa);
        }

        // GET: LvhKhoas/Edit/5
        public ActionResult LvhEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhKhoa lvhKhoa = db.LvhKhoas.Find(id);
            if (lvhKhoa == null)
            {
                return HttpNotFound();
            }
            return View(lvhKhoa);
        }

        // POST: LvhKhoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhEdit([Bind(Include = "LvhMaKH,LvhTenKH")] LvhKhoa lvhKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lvhKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }
            return View(lvhKhoa);
        }

        // GET: LvhKhoas/Delete/5
        public ActionResult LvhDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhKhoa lvhKhoa = db.LvhKhoas.Find(id);
            if (lvhKhoa == null)
            {
                return HttpNotFound();
            }
            return View(lvhKhoa);
        }

        // POST: LvhKhoas/Delete/5
        [HttpPost, ActionName("LvhDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LvhKhoa lvhKhoa = db.LvhKhoas.Find(id);
            db.LvhKhoas.Remove(lvhKhoa);
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
