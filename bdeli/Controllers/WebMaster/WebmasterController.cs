using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;

namespace bdeli.Controllers.WebMaster
{
    public class WebmasterController : Controller
    {
		bDeliEntities db = new bDeliEntities();
        // GET: Webmaster
        public ActionResult Index()
        {
            if (Session["Authentication"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            if (Username.Equals("admin"))
            {
		var rs = db.bD_Account.Find(1);
                if (rs.Password.Equals(Password))
                {
                    Session["Authentication"] = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login", "Webmaster");
                }
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            if (Session["Authentication"] != null)
            {
                return RedirectToAction("null");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}