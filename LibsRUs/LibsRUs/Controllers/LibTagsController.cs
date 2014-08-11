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
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            LibTag libTag = db.LibTags.Find(id);
            db.LibTags.Remove(libTag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetLibTagItem(Int32 typeID, String text)
        {
            LibTag libTag = db.LibTags.SingleOrDefault(x => x.TagText == text);
            if(libTag == null)
            {
                return Json(new { Succes = false, ErrorText = "Tag doesn't exist" });
            }
            return PartialView("_LibTag", libTag);
        }

        public ActionResult GetLibTagItemRemovable(Int32 typeID, String text)
        {
            LibTag libTag = db.LibTags.SingleOrDefault(x => x.TagText == text);
            if (libTag == null)
            {
                return Json(new { Succes = false, ErrorText = "Tag doesn't exist" });
            }
            return PartialView("_LibTagRemovable", libTag);
        }

        public ActionResult GetLibTags(String term)
        {
            List<LibTag> libTags = db.LibTags.ToList();
            List<String> results = (from libTag in libTags where libTag.TagText.Contains(term) select libTag.TagText).ToList();
            return Json(results, JsonRequestBehavior.AllowGet);
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
