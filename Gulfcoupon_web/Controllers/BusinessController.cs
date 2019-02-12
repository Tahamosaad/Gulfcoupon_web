using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.IO;

namespace Gulfcoupon_web.Controllers
{
    public class BusinessController : Controller
    {
        private GulfEntities db = new GulfEntities();

        // GET: Business
        public ActionResult Index()
        {
            var businessName = db.BusinessName.Include(b => b.Branch).Include(b => b.BusinessType);
            return View(businessName.ToList());
        }

        // GET: Business/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessName businessName = db.BusinessName.Find(id);
            if (businessName == null)
            {
                return HttpNotFound();
            }
            return View(businessName);
        }

        // GET: Business/Create
        public ActionResult Create()
        {
            ViewBag.Branch_id = new SelectList(db.Branch, "ID", "Branchname");
            ViewBag.BusinessType_id = new SelectList(db.BusinessType, "ID", "BusinessType1");
            return View();
        }

        // POST: Business/Create
      
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "ID,BusinessName1,Logo,Email,Website,BusinessType_id,Branch_id")]BusinessName businessName, HttpPostedFileBase Logo)
        {
            string newname = "";
            string extention = Path.GetExtension(Logo.FileName);
            newname = DateTime.Now.Ticks.ToString() + extention;
            var mypath = Path.Combine(Server.MapPath("~/Logoimg"), newname);
            Logo.SaveAs(mypath);
            if (ModelState.IsValid)
            {
                businessName.Logo = newname;
               
                db.BusinessName.Add(businessName);
                if (db.SaveChanges() > 0)
                {
                    TempData["success"] = "success add business";
                }
                else
                {
                    TempData["error"] = "not add yet";
                }
                return RedirectToAction("Index");
            }

            ViewBag.Branch_id = new SelectList(db.Branch, "ID", "Branchname", businessName.Branch_id);
            ViewBag.BusinessType_id = new SelectList(db.BusinessType, "ID", "BusinessType1", businessName.BusinessType_id);
            return View(businessName);
        }

        // GET: Business/Edit/5
        public BusinessName Get(int id)
        {
            var query = db.BusinessName.Where(x => x.ID == id).FirstOrDefault();
            if (query != null)
            {
                return query;
            }
            return null;
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessName businessName = db.BusinessName.Find(id);
            if (businessName == null)
            {
                return HttpNotFound();
            }
            ViewBag.Branch_id = new SelectList(db.Branch, "ID", "Branchname", businessName.Branch_id);
            ViewBag.BusinessType_id = new SelectList(db.BusinessType, "ID", "BusinessType1", businessName.BusinessType_id);
            return View(businessName);
        }

        // POST: Business/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BusinessName1,Logo,Email,Website,BusinessType_id,Branch_id")] BusinessName businessName)
        {
            if (ModelState.IsValid)
            {
                var query = Get(businessName.ID);
                if (query != null)
                {
                    query.ID = businessName.ID;
                    query.Logo = businessName.Logo;
                    query.Website = businessName.Website;
                    query.Email = businessName.Email;
                    query.BusinessName1 = businessName.BusinessName1;
                    query.BusinessType_id = businessName.BusinessType_id;
                    query.Branch_id = businessName.Branch_id;
                }
                    //db.Entry(businessName).State = EntityState.Modified;
                    db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branch_id = new SelectList(db.Branch, "ID", "Branchname", businessName.Branch_id);
            ViewBag.BusinessType_id = new SelectList(db.BusinessType, "ID", "BusinessType1", businessName.BusinessType_id);
            return View(businessName);
        }

        // GET: Business/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessName businessName = db.BusinessName.Find(id);
            if (businessName == null)
            {
                return HttpNotFound();
            }
            return View(businessName);
        }

        // POST: Business/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessName businessName = db.BusinessName.Find(id);
            db.BusinessName.Remove(businessName);
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
