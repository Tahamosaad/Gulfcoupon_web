using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.IO;
namespace Gulfcoupon_web.Controllers
{
    public class CountriesController : Controller
    {
        GulfEntities db = new GulfEntities();

        // GET: Countries
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create_country()
        {
            ViewBag.country_id = new SelectList(db.Countries.ToList(), "Country_ID", "name");
            return View();
        }
        [HttpPost]
        public ActionResult Create_country(Countries info, HttpPostedFileBase flag)
        {
            string newname = "";
            string extention = Path.GetExtension(flag.FileName);
            newname = DateTime.Now.Ticks.ToString() + extention;
            var mypath = Path.Combine(Server.MapPath("~/FlagImg"), newname);
            flag.SaveAs(mypath);
            if (ModelState.IsValid)
            {
                info.flag = newname;
                db.Countries.Add(info);
                if (db.SaveChanges() > 0)
                {
                    TempData["success"] = "success add country";
                }
                else
                {
                    TempData["error"] = "not add yet";
                }
            }
            else
            {
                TempData["error"] = "Check Some Errors";
            }

            return RedirectToAction("Create_country");

        }
        public PartialViewResult GetAll()
        {
            return PartialView("_GetAll", db.Countries.ToList());
        }
    }

}