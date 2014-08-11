using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibsRUs.DAL;
using LibsRUs.Models;

namespace LibsRUs.Controllers
{
    public class LibTagTypesController : Controller
    {
        private LibsRUsContext db = new LibsRUsContext();

        // GET: LibTagTypes
        public ActionResult Index()
        {
            return View(db.LibTagTypes.ToList());
        }

        // GET: LibTagTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibTagType libTagType = db.LibTagTypes.Find(id);
            if (libTagType == null)
            {
                return HttpNotFound();
            }
            return View(libTagType);
        }

        // GET: LibTagTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibTagTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] LibTagType libTagType)
        {
            if (ModelState.IsValid)
            {
                db.LibTagTypes.Add(libTagType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libTagType);
        }

        // GET: LibTagTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibTagType libTagType = db.LibTagTypes.Find(id);
            if (libTagType == null)
            {
                return HttpNotFound();
            }
            return View(libTagType);
        }

        // POST: LibTagTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] LibTagType libTagType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libTagType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libTagType);
        }

        // GET: LibTagTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibTagType libTagType = db.LibTagTypes.Find(id);
            if (libTagType == null)
            {
                return HttpNotFound();
            }
            return View(libTagType);
        }

        // POST: LibTagTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibTagType libTagType = db.LibTagTypes.Find(id);
            db.LibTagTypes.Remove(libTagType);
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
