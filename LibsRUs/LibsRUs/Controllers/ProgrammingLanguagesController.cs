using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibsRUs.Models;
using LibsRUs.DAL;

namespace LibsRUs.Controllers
{
    public class ProgrammingLanguagesController : Controller
    {
        private LibsRUsContext db = new LibsRUsContext();

        // GET: /ProgrammingLanguages/
        public ActionResult Index()
        {
            return View(db.ProgrammingLanguages.ToList());
        }

        // GET: /ProgrammingLanguages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammingLanguage programminglanguage = db.ProgrammingLanguages.Find(id);
            if (programminglanguage == null)
            {
                return HttpNotFound();
            }
            return View(programminglanguage);
        }

        // GET: /ProgrammingLanguages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ProgrammingLanguages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Abbreviation")] ProgrammingLanguage programminglanguage)
        {
            if (ModelState.IsValid)
            {
                db.ProgrammingLanguages.Add(programminglanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programminglanguage);
        }

        // GET: /ProgrammingLanguages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammingLanguage programminglanguage = db.ProgrammingLanguages.Find(id);
            if (programminglanguage == null)
            {
                return HttpNotFound();
            }
            return View(programminglanguage);
        }

        // POST: /ProgrammingLanguages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Abbreviation")] ProgrammingLanguage programminglanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programminglanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programminglanguage);
        }

        // GET: /ProgrammingLanguages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgrammingLanguage programminglanguage = db.ProgrammingLanguages.Find(id);
            if (programminglanguage == null)
            {
                return HttpNotFound();
            }
            return View(programminglanguage);
        }

        // POST: /ProgrammingLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgrammingLanguage programminglanguage = db.ProgrammingLanguages.Find(id);
            db.ProgrammingLanguages.Remove(programminglanguage);
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
