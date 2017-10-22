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
    public class ReviewFestivalsController : Controller
    {
        private TravelOhioMVCContext db = new TravelOhioMVCContext();

        // GET: ReviewFestivals
        public ActionResult Index()
        {
            var reviewFestivals = db.ReviewFestivals.Include(r => r.Festival);
            return View(reviewFestivals.ToList());
        }

        // GET: ReviewFestivals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewFestival reviewFestival = db.ReviewFestivals.Find(id);
            if (reviewFestival == null)
            {
                return HttpNotFound();
            }
            return View(reviewFestival);
        }

        // GET: ReviewFestivals/Create
        public ActionResult Create()
        {
            ViewBag.FestivalID = new SelectList(db.Festivals, "FestivalID", "LocalFestival");
            return View();
        }

        // POST: ReviewFestivals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewFestivalID,UserName,Title,Rating,Attended,ReviewText,FestivalID")] ReviewFestival reviewFestival)
        {
            if (ModelState.IsValid)
            {
                db.ReviewFestivals.Add(reviewFestival);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FestivalID = new SelectList(db.Festivals, "FestivalID", "LocalFestival", reviewFestival.FestivalID);
            return View(reviewFestival);
        }

        // GET: ReviewFestivals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewFestival reviewFestival = db.ReviewFestivals.Find(id);
            if (reviewFestival == null)
            {
                return HttpNotFound();
            }
            ViewBag.FestivalID = new SelectList(db.Festivals, "FestivalID", "LocalFestival", reviewFestival.FestivalID);
            return View(reviewFestival);
        }

        // POST: ReviewFestivals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewFestivalID,UserName,Title,Rating,Attended,ReviewText,FestivalID")] ReviewFestival reviewFestival)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewFestival).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FestivalID = new SelectList(db.Festivals, "FestivalID", "LocalFestival", reviewFestival.FestivalID);
            return View(reviewFestival);
        }

        // GET: ReviewFestivals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewFestival reviewFestival = db.ReviewFestivals.Find(id);
            if (reviewFestival == null)
            {
                return HttpNotFound();
            }
            return View(reviewFestival);
        }

        // POST: ReviewFestivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewFestival reviewFestival = db.ReviewFestivals.Find(id);
            db.ReviewFestivals.Remove(reviewFestival);
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
