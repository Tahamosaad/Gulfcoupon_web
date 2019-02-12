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
    public class BranchesController : Controller
    {
        private GulfEntities db = new GulfEntities();

        // GET: Branches
        public ActionResult Index()
        {
            var branch = db.Branch.Include(b => b.Cities).Include(b => b.Countries);
            return View(branch.ToList());
        }

        // GET: Branches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branch.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Branches/Create
        public ActionResult Create()
        {
            ViewBag.City_id = new SelectList(db.Cities, "City_id", "name");
            ViewBag.Country_id = new SelectList(db.Countries, "Country_ID", "name");
            return View();
        }

        // POST: Branches/Create
        
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Branchname,Address,Phone,City_id,Country_id")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Branch.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.City_id = new SelectList(db.Cities, "City_id", "name", branch.City_id);
            ViewBag.Country_id = new SelectList(db.Countries, "Country_ID", "name", branch.Country_id);
            return View(branch);
        }

        // GET: Branches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branch.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            ViewBag.City_id = new SelectList(db.Cities, "City_id", "name", branch.City_id);
            ViewBag.Country_id = new SelectList(db.Countries, "Country_ID", "name", branch.Country_id);
            return View(branch);
        }

        // POST: Branches/Edit/5
        
        [HttpPost]
      
        public ActionResult Edit([Bind(Include = "ID,Branchname,Address,Phone,City_id,Country_id")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.City_id = new SelectList(db.Cities, "City_id", "name", branch.City_id);
            ViewBag.Country_id = new SelectList(db.Countries, "Country_ID", "name", branch.Country_id);
            return View(branch);
        }

        // GET: Branches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branch.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Branch branch = db.Branch.Find(id);
            db.Branch.Remove(branch);
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
