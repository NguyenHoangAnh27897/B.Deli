using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bdeli.Models;
using System.Web.Mvc;
using System.IO;

namespace bdeli.Controllers.WebMaster
{

    public class HomeMasterController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: HomeMaster
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.bD_Slide.Where(s => s.id == 1);
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
                string Images = "";
                if (images != null)
                {
                    foreach (HttpPostedFileBase file in images)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var filename = Path.GetFileName(file.FileName);
                                var fname = filename.Replace(" ", "_");
                                var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                                file.SaveAs(path);
                                Images += fname + ",";
                            }
                        }
                    }
                    if (Images != "" && Images.Contains(","))
                    {
                        Images = Images.Remove(Images.Length - 1);
                    }
                }
                var home = db.bD_Slide.Find(1);
                home.Title = title;
                home.Description = description;
                if (Images != "")
                {
                    home.Images = Images;
                }
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
