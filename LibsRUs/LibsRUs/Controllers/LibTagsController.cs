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
    public class LibTagsController : Controller
    {
        private LibsRUsContext db = new LibsRUsContext();

        // GET: LibTags
        public ActionResult Index()
        {
            return View(db.LibTags.ToList());
        }

        // GET: LibTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibTag libTag = db.LibTags.Find(id);
            if (libTag == null)
            {
                return HttpNotFound();
            }
            return View(libTag);
        }

        // GET: LibTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TagText")] LibTag libTag)
        {
            if (ModelState.IsValid)
            {
                db.LibTags.Add(libTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libTag);
        }

        // GET: LibTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibTag libTag = db.LibTags.Find(id);
            if (libTag == null)
            {
                return HttpNotFound();
            }
            return View(libTag);
        }

        // POST: LibTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TagText")] LibTag libTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libTag);
        }

        // GET: LibTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibTag libTag = db.LibTags.Find(id);
            if (libTag == null)
            {
                return HttpNotFound();
            }
            return View(libTag);
        }

        // POST: LibTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibTag libTag = db.LibTags.Find(id);
            db.LibTags.Remove(libTag);
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
