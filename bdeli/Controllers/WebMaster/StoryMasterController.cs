using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;
using System.IO;

namespace bdeli.Controllers.WebMaster
{
    public class StoryMasterController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: StoryMaster
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                try
                {
                    var rs = db.bD_Introduce.Where(s => s.id == 1);
                    return View(rs);
                }catch(Exception ex)
                {
                    return RedirectToAction("Index", "Error");
                }

            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
        [HttpPost]
        public ActionResult Edit(string title, string des, string subtitle, HttpPostedFileBase images, HttpPostedFileBase images1)
        {
            if (Session["Authentication"] != null)
            {
                string Images = "";
                if (images != null)
                {
                    if (images.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(images.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        images.SaveAs(path);
                        Images += fname;
                    }
                }

                string Images1 = "";
                if (images1 != null)
                {
                    if (images1.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(images1.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        images1.SaveAs(path);
                        Images1 += fname;
                    }
                }

                var st = db.bD_Introduce.Find(1);
                st.Title = title;
                st.Description = des;
                st.Subtitle = subtitle;

                if (Images != "")
                {
                    st.Images = Images;
                }
                if (Images1 != "")
                {
                    st.Images1 = Images1;
                }
                db.Entry(st).State = System.Data.Entity.EntityState.Modified;
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