using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Gulfcoupon_web.Controllers
{
    public class CitiesController : Controller
    {
        private GulfEntities db = new GulfEntities();

        // GET: Cities
        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.Countries);
            return View(cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities cities = db.Cities.Find(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            return View(cities);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.Country_id = new SelectList(db.Countries, "Country_ID", "name");
            return View();
        }

        // POST: Cities/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "City_id,name,Latitude,Longitude,Country_id")] Cities cities)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(cities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_id = new SelectList(db.Countries, "Country_ID", "name", cities.Country_id);
            return View(cities);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities cities = db.Cities.Find(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country_id = new SelectList(db.Countries, "Country_ID", "name", cities.Country_id);
            return View(cities);
        }

        // POST: Cities/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "City_id,name,Latitude,Longitude,Country_id")] Cities cities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_id = new SelectList(db.Countries, "Country_ID", "name", cities.Country_id);
            return View(cities);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cities cities = db.Cities.Find(id);
            if (cities == null)
            {
                return HttpNotFound();
            }
            return View(cities);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cities cities = db.Cities.Find(id);
            db.Cities.Remove(cities);
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
