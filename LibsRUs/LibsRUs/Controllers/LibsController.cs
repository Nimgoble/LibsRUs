﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibsRUs.DAL;
using LibsRUs.Models;
using LibsRUs.ViewModels;

namespace LibsRUs.Controllers
{
    public class LibsController : Controller
    {
        private LibsRUsContext db = new LibsRUsContext();

        // GET: Libs
        public ActionResult Index()
        {
            //ViewBag.LibTagTypes = from libTagType in db.LibTagTypes select new { ID = libTagType.ID, Name = libTagType.Name, LibTags = libTagType.LibTags.OrderByDescending(x => x.Libs.Count).Take(10), HasMoreLibTags = libTagType.LibTags.Count > 10 };
            //ViewBag.LibTags = db.LibTags.OrderByDescending(x => x.Libs.Count).Take(10).ToList();
            //ViewBag.LibTagTypes = db.LibTagTypes;
            ViewBag.LibTagTypes =
                from
                    libTagType
                in db.LibTagTypes
                select
                    new LibTagTypeSideBarViewModel()
                    {
                        ID = libTagType.ID,
                        Name = libTagType.Name,
                        LibTags = libTagType.LibTags.OrderByDescending(x => x.Libs.Count).Take(10).ToList(),
                        HasMoreLibTags = libTagType.LibTags.Count > 10
                    };
            return View(db.Libs.ToList());
        }

        // GET: Libs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lib lib = db.Libs.Include("LibTags").SingleOrDefault(x => x.ID == id);
            if (lib == null)
            {
                return HttpNotFound();
            }
            return View(lib);
        }

        // GET: Libs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Name,Description,LibURL,LibTags")] Lib lib)
        {
            if (ModelState.IsValid)
            {
                foreach(LibTag libTag in lib.LibTags)
                    db.LibTags.Attach(libTag);

                db.Libs.Add(lib);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = lib.ID });
            }

            return View(lib);
        }

        // GET: Libs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lib lib = db.Libs.Find(id);
            if (lib == null)
            {
                return HttpNotFound();
            }
            return View(lib);
        }

        // POST: Libs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,LibURL")] Lib lib)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lib).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lib);
        }

        // GET: Libs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lib lib = db.Libs.Find(id);
            if (lib == null)
            {
                return HttpNotFound();
            }
            return View(lib);
        }

        // POST: Libs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Lib lib = db.Libs.Find(id);
            db.Libs.Remove(lib);
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
