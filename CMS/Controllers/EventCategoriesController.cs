using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models.CMSModel;

namespace CMS.Controllers
{
    public class EventCategoriesController : Controller
    {
        private CMSContext db = new CMSContext();

        // GET: EventCategories
        public ActionResult Index()
        {
            return View(db.EventCategories.ToList());
        }

        // GET: EventCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCategory eventCategory = db.EventCategories.Find(id);
            if (eventCategory == null)
            {
                return HttpNotFound();
            }
            return View(eventCategory);
        }

        // GET: EventCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventCatID,Name,Outdoor,Family")] EventCategory eventCategory)
        {
            if (ModelState.IsValid)
            {
                db.EventCategories.Add(eventCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventCategory);
        }

        // GET: EventCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCategory eventCategory = db.EventCategories.Find(id);
            if (eventCategory == null)
            {
                return HttpNotFound();
            }
            return View(eventCategory);
        }

        // POST: EventCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventCatID,Name,Outdoor,Family")] EventCategory eventCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventCategory);
        }

        // GET: EventCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCategory eventCategory = db.EventCategories.Find(id);
            if (eventCategory == null)
            {
                return HttpNotFound();
            }
            return View(eventCategory);
        }

        // POST: EventCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventCategory eventCategory = db.EventCategories.Find(id);
            db.EventCategories.Remove(eventCategory);
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
