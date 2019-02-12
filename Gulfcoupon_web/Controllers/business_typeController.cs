using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.IO;
namespace Gulfcoupon_web.Controllers
{
    public class business_typeController : Controller
    {
        GulfEntities db = new GulfEntities();

      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create_business()
        {
            ViewBag.country_id = new SelectList(db.BusinessType.ToList(), "ID", "BusinessType");
            return View();
        }
        [HttpPost]
        public ActionResult Create_business(BusinessType info, HttpPostedFileBase Photo)
        {
            string newname = "";
            string extention = Path.GetExtension(Photo.FileName);
            newname = DateTime.Now.Ticks.ToString() + extention;
            var mypath = Path.Combine(Server.MapPath("~/businessImg"), newname);
            Photo.SaveAs(mypath);
            if (ModelState.IsValid)
            {
                info.Photo = newname;
                db.BusinessType.Add(info);
                if (db.SaveChanges() > 0)
                {
                    TempData["success"] = "success add businesstype";
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

            return RedirectToAction("Create_business");

        }
        public PartialViewResult GetAll()
        {
            return PartialView("_GetAll", db.BusinessType.ToList());
        }
    }
}
