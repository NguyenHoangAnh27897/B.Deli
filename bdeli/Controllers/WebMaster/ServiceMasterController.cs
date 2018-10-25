using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;
using System.IO;

namespace bdeli.Controllers.WebMaster
{
    public class ServiceMasterController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: ServiceMaster
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                try
                {
                    var rs = db.bD_Service.Where(st => st.id == 1);
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
        public ActionResult Edit(string title1, string des1, string title2, string des2, string title3, string des3, HttpPostedFileBase images1, HttpPostedFileBase images2, HttpPostedFileBase images3)
        {
            if(Session["Authentication"] != null)
            {

                string Images1 = "";
                if (images1 != null)
                {
                    if (images1.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(images1.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        images1.SaveAs(path);
                        Images1 += fname ;
                    }
                }   

                string Images2 = "";
                if (images2 != null)
                {
                    if (images2.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(images2.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        images2.SaveAs(path);
                        Images2 += fname;
                    }
                }
                string Images3 = "";
                if (images3 != null)
                {
                    if (images3.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(images3.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        images3.SaveAs(path);
                        Images3 += fname;
                    }
                }
                var home = db.bD_Service.Find(1);
                home.Title1 = title1;
                home.Description1 = des1;
                home.Title2 = title2;
                home.Description2 = des2;
                home.Title3 = title3;
                home.Description3 = des3;
                if (Images1 != "")
                {
                    home.Images1 = Images1;
                }
                if (Images2 != "")
                {
                    home.Images2 = Images2;
                }
                if (Images3 != "")
                {
                    home.Images3 = Images3;
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