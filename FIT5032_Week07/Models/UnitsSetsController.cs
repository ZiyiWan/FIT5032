using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_Week07.Models
{
    public class UnitsSetsController : Controller
    {
        private Model2 db = new Model2();

        // GET: UnitsSets
        public ActionResult Index()
        {
            var unitsSet = db.UnitsSet.Include(u => u.StudentsSet);
            return View(unitsSet.ToList());
        }

        // GET: UnitsSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitsSet unitsSet = db.UnitsSet.Find(id);
            if (unitsSet == null)
            {
                return HttpNotFound();
            }
            return View(unitsSet);
        }

        // GET: UnitsSets/Create
        public ActionResult Create()
        {
            ViewBag.StudentsId = new SelectList(db.StudentsSet, "Id", "FirstName");
            return View();
        }

        // POST: UnitsSets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StudentsId")] UnitsSet unitsSet)
        {
            if (ModelState.IsValid)
            {
                db.UnitsSet.Add(unitsSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentsId = new SelectList(db.StudentsSet, "Id", "FirstName", unitsSet.StudentsId);
            return View(unitsSet);
        }

        // GET: UnitsSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitsSet unitsSet = db.UnitsSet.Find(id);
            if (unitsSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentsId = new SelectList(db.StudentsSet, "Id", "FirstName", unitsSet.StudentsId);
            return View(unitsSet);
        }

        // POST: UnitsSets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StudentsId")] UnitsSet unitsSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unitsSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentsId = new SelectList(db.StudentsSet, "Id", "FirstName", unitsSet.StudentsId);
            return View(unitsSet);
        }

        // GET: UnitsSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnitsSet unitsSet = db.UnitsSet.Find(id);
            if (unitsSet == null)
            {
                return HttpNotFound();
            }
            return View(unitsSet);
        }

        // POST: UnitsSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitsSet unitsSet = db.UnitsSet.Find(id);
            db.UnitsSet.Remove(unitsSet);
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
