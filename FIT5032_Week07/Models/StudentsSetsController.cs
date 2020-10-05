using Microsoft.AspNet.Identity;
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
    public class StudentsSetsController : Controller
    {
        private Model2 db = new Model2();

        // GET: StudentsSets
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var students = db.StudentsSet.Where(s => s.UserId == userId).ToList();

            return View(students);
        }

        // GET: StudentsSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsSet studentsSet = db.StudentsSet.Find(id);
            if (studentsSet == null)
            {
                return HttpNotFound();
            }
            return View(studentsSet);
        }

        // GET: StudentsSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsSets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] StudentsSet studentsSet)
        {
            studentsSet.UserId = User.Identity.GetUserId();

            ModelState.Clear();
            TryValidateModel(studentsSet);
            
            
            if (ModelState.IsValid)
            {
                db.StudentsSet.Add(studentsSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentsSet);
        }

        // GET: StudentsSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsSet studentsSet = db.StudentsSet.Find(id);
            if (studentsSet == null)
            {
                return HttpNotFound();
            }
            return View(studentsSet);
        }

        // POST: StudentsSets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,UserId")] StudentsSet studentsSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentsSet);
        }

        // GET: StudentsSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsSet studentsSet = db.StudentsSet.Find(id);
            if (studentsSet == null)
            {
                return HttpNotFound();
            }
            return View(studentsSet);
        }

        // POST: StudentsSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsSet studentsSet = db.StudentsSet.Find(id);
            db.StudentsSet.Remove(studentsSet);
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
