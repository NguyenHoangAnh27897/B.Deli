using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bdeli.Models;
using System.Web.Mvc;
using System.IO;

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
        public ActionResult Edit(string title, string des, HttpPostedFileBase video)
        {
            if (Session["Authentication"] != null)
            {
                string Video = "";
                if (video != null)
                {
                    if (video.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(video.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Video"), fname);
                        video.SaveAs(path);
                        Video += fname;
                    }

                }
                var home = db.bD_Video.Find(1);
                home.Description = des;
                home.Title = title;
                if (Video != null)
                {
                    home.Video = Video;
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