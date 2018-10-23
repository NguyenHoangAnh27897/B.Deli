using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bdeli.Models;
using System.Web.Mvc;

namespace bdeli.Controllers.WebMaster
{
    public class VideoController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.bD_Video.Where(s => s.id == 1);
                return View(rs);
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }

        [HttpPost]
        public ActionResult Edit(string title, string description, HttpPostedFileBase[] images)
        {
            if (Session["Authentication"] != null)
            {
                var home = db.bD_Video.Find(1);
                home.Description = description;
                home.Title = title;
                db.Entry(home).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
    }
}