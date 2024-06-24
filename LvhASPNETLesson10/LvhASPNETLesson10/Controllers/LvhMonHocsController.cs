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
    public class LvhMonHocsController : Controller
    {
        private LvhK22CNT1Lesson09Entities db = new LvhK22CNT1Lesson09Entities();

        // GET: LvhMonHocs
        public ActionResult LvhIndex()
        {
            return View(db.LvhMonHocs.ToList());
        }

        // GET: LvhMonHocs/Details/5
        public ActionResult LvhDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhMonHoc lvhMonHoc = db.LvhMonHocs.Find(id);
            if (lvhMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(lvhMonHoc);
        }

        // GET: LvhMonHocs/Create
        public ActionResult LvhCreate()
        {
            return View();
        }

        // POST: LvhMonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhCreate([Bind(Include = "LvhMaMH,LvhTenMH,LvhSotiet")] LvhMonHoc lvhMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.LvhMonHocs.Add(lvhMonHoc);
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }

            return View(lvhMonHoc);
        }

        // GET: LvhMonHocs/Edit/5
        public ActionResult LvhEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhMonHoc lvhMonHoc = db.LvhMonHocs.Find(id);
            if (lvhMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(lvhMonHoc);
        }

        // POST: LvhMonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhEdit([Bind(Include = "LvhMaMH,LvhTenMH,LvhSotiet")] LvhMonHoc lvhMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lvhMonHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lvhMonHoc);
        }

        // GET: LvhMonHocs/Delete/5
        public ActionResult LvhDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhMonHoc lvhMonHoc = db.LvhMonHocs.Find(id);
            if (lvhMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(lvhMonHoc);
        }

        // POST: LvhMonHocs/Delete/5
        [HttpPost, ActionName("LvhDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LvhDeleteConfirmed(string id)
        {
            LvhMonHoc lvhMonHoc = db.LvhMonHocs.Find(id);
            db.LvhMonHocs.Remove(lvhMonHoc);
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
