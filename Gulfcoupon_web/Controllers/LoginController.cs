using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gulfcoupon_web.Models;
using DAL;
namespace Gulfcoupon_web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(UserModel model)
        {
            GulfEntities  db = new GulfEntities();
            var sp = db.GetLoginInfo(model.UserName, model.Password);

            var item = sp.FirstOrDefault();
            if (item == "Success")
            {

                return Redirect("/Main/Index");
            }
            else if (item == "User Does not Exists")

            {
                TempData["NotValidUser"] = item;
            }
            else
            {
                TempData["Failedcount"] = item;
            }

            return View("LoginPage");
        }
      
}
}