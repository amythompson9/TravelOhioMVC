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
    public class ReviewCitiesController : Controller
    {
        private TravelOhioMVCContext db = new TravelOhioMVCContext();

        // GET: ReviewCities
        public ActionResult Index()
        {
            var reviewCities = db.ReviewCities.Include(r => r.City);
            return View(reviewCities.ToList());
        }

        // GET: ReviewCities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewCity reviewCity = db.ReviewCities.Find(id);
            if (reviewCity == null)
            {
                return HttpNotFound();
            }
            return View(reviewCity);
        }

        // GET: ReviewCities/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityMetro");
            return View();
        }

        // POST: ReviewCities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewCityID,UserName,Title,Rating,Attended,ReviewText,CityID")] ReviewCity reviewCity)
        {
            if (ModelState.IsValid)
            {
                db.ReviewCities.Add(reviewCity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityMetro", reviewCity.CityID);
            return View(reviewCity);
        }

        // GET: ReviewCities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewCity reviewCity = db.ReviewCities.Find(id);
            if (reviewCity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityMetro", reviewCity.CityID);
            return View(reviewCity);
        }

        // POST: ReviewCities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewCityID,UserName,Title,Rating,Attended,ReviewText,CityID")] ReviewCity reviewCity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewCity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityMetro", reviewCity.CityID);
            return View(reviewCity);
        }

        // GET: ReviewCities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewCity reviewCity = db.ReviewCities.Find(id);
            if (reviewCity == null)
            {
                return HttpNotFound();
            }
            return View(reviewCity);
        }

        // POST: ReviewCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewCity reviewCity = db.ReviewCities.Find(id);
            db.ReviewCities.Remove(reviewCity);
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
