using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelOhioMVC.Models;

namespace TravelOhioMVC.Controllers
{
    public class ReviewAttractionsController : Controller
    {
        private TravelOhioMVCContext db = new TravelOhioMVCContext();

        // GET: ReviewAttractions
        public ActionResult Index()
        {
            var reviewAttractions = db.ReviewAttractions.Include(r => r.Attraction);
            return View(reviewAttractions.ToList());
        }

        // GET: ReviewAttractions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewAttraction reviewAttraction = db.ReviewAttractions.Find(id);
            if (reviewAttraction == null)
            {
                return HttpNotFound();
            }
            return View(reviewAttraction);
        }

        // GET: ReviewAttractions/Create
        public ActionResult Create()
        {
            ViewBag.AttractionID = new SelectList(db.Attractions, "AttractionID", "LocalAttraction");
            return View();
        }

        // POST: ReviewAttractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewAttractionID,UserName,Title,Rating,Attended,ReviewText,AttractionID")] ReviewAttraction reviewAttraction)
        {
            if (ModelState.IsValid)
            {
                db.ReviewAttractions.Add(reviewAttraction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttractionID = new SelectList(db.Attractions, "AttractionID", "LocalAttraction", reviewAttraction.AttractionID);
            return View(reviewAttraction);
        }

        // GET: ReviewAttractions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewAttraction reviewAttraction = db.ReviewAttractions.Find(id);
            if (reviewAttraction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttractionID = new SelectList(db.Attractions, "AttractionID", "LocalAttraction", reviewAttraction.AttractionID);
            return View(reviewAttraction);
        }

        // POST: ReviewAttractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewAttractionID,UserName,Title,Rating,Attended,ReviewText,AttractionID")] ReviewAttraction reviewAttraction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewAttraction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttractionID = new SelectList(db.Attractions, "AttractionID", "LocalAttraction", reviewAttraction.AttractionID);
            return View(reviewAttraction);
        }

        // GET: ReviewAttractions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewAttraction reviewAttraction = db.ReviewAttractions.Find(id);
            if (reviewAttraction == null)
            {
                return HttpNotFound();
            }
            return View(reviewAttraction);
        }

        // POST: ReviewAttractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewAttraction reviewAttraction = db.ReviewAttractions.Find(id);
            db.ReviewAttractions.Remove(reviewAttraction);
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
