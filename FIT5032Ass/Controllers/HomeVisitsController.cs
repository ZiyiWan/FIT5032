using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032Ass.Models;

namespace FIT5032Ass.Controllers
{
    public class HomeVisitsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: HomeVisits
        public ActionResult Index()
        {
            var homeVisitSet = db.HomeVisitSet.Include(h => h.Teacher);
            return View(homeVisitSet.ToList());
        }

        // GET: HomeVisits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeVisit homeVisit = db.HomeVisitSet.Find(id);
            if (homeVisit == null)
            {
                return HttpNotFound();
            }
            return View(homeVisit);
        }

        // GET: HomeVisits/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(db.TeacherSet, "Id", "FirstName");
            return View();
        }

        // POST: HomeVisits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Time,TeacherId")] HomeVisit homeVisit)
        {
            if (ModelState.IsValid)
            {
                db.HomeVisitSet.Add(homeVisit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeacherId = new SelectList(db.TeacherSet, "Id", "FirstName", homeVisit.TeacherId);
            return View(homeVisit);
        }

        // GET: HomeVisits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeVisit homeVisit = db.HomeVisitSet.Find(id);
            if (homeVisit == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherId = new SelectList(db.TeacherSet, "Id", "FirstName", homeVisit.TeacherId);
            return View(homeVisit);
        }

        // POST: HomeVisits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Time,TeacherId")] HomeVisit homeVisit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeVisit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(db.TeacherSet, "Id", "FirstName", homeVisit.TeacherId);
            return View(homeVisit);
        }

        // GET: HomeVisits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeVisit homeVisit = db.HomeVisitSet.Find(id);
            if (homeVisit == null)
            {
                return HttpNotFound();
            }
            return View(homeVisit);
        }

        // POST: HomeVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeVisit homeVisit = db.HomeVisitSet.Find(id);
            db.HomeVisitSet.Remove(homeVisit);
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
