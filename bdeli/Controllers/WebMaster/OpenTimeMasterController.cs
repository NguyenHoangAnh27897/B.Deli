﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;

namespace bdeli.Controllers.WebMaster
{
    public class OpenTimeMasterController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: OpenTimeMaster
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.bD_OpenTime.Where(st => st.id ==1 );
                return View(rs);
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        } 

        [HttpPost]
        public ActionResult Edit(string mon, string tue, string wen, string thu, string fri, string sat, string sun)
        {
            if (Session["Authentication"] != null)
            {
                var home = db.bD_OpenTime.Find(1);
                home.mon = mon;
                home.tue = tue;
                home.wen = wen;
                home.thu = thu;
                home.fri = fri;
                home.sat = sat;
                home.sun = sun;
                db.Entry(home).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return View("Edit");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster"); 
            }
        }
    }
}