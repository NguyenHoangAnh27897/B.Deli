using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;
namespace bdeli.Controllers.WebMaster
{
    public class ImageController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: Image
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var sr = db.bD_Images.Where(st => st.id == 1);
                return View(sr);
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }           
        }

        [HttpPost]
        public ActionResult Edit(string title1, string title2, string title3, string title4, string title5, string title6, string title7, string title8, HttpPostedFileBase Images1, HttpPostedFileBase Images2, HttpPostedFileBase Images3, HttpPostedFileBase Images4, HttpPostedFileBase Images5, HttpPostedFileBase Images6, HttpPostedFileBase Images7, HttpPostedFileBase Images8)
        {
            if (Session["Authentication"] != null)
            {
                string images1 = "";
                if (Images1 != null)
                {
                    if (Images1.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images1.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        Images1.SaveAs(path);
                        images1 += fname;
                    }
                }

                string images2 = "";
                if (Images2 != null)
                {
                    if (Images2.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images2.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        Images2.SaveAs(path);
                        images2 += fname;
                    }
                }

                string images3 = "";
                if (Images3 != null)
                {
                    if (Images3.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images3.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        Images3.SaveAs(path);
                        images3 += fname;
                    }
                }

                string images4 = "";
                if (Images4 != null)
                {
                    if (Images4.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images4.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        Images4.SaveAs(path);
                        images4 += fname;
                    }
                }

                string images5= "";
                if (Images5 != null)
                {
                    if (Images5.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images5.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        Images5.SaveAs(path);
                        images5 += fname;
                    }
                }

                string images6 = "";
                if (Images6 != null)
                {
                    if (Images6.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images6.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        Images6.SaveAs(path);
                        images6 += fname;
                    }
                }

                string images7 = "";
                if (Images7 != null)
                {
                    if (Images7.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images7.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        Images7.SaveAs(path);
                        images7 += fname;
                    }
                }

                string images8 = "";
                if (Images8 != null)
                {
                    if (Images8.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(Images8.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageHome"), fname);
                        Images8.SaveAs(path);
                        images8 += fname;
                    }
                }

                var home = db.bD_Images.Find(1);
                home.Title1 = title1;
                home.Title2 = title2;
                home.Title3 = title3;
                home.Title4 = title4;
                home.Title5 = title5;
                home.Title6 = title6;
                home.Title7 = title7;
                home.Title8 = title8;
                if (images1 != "")
                {
                    home.image1 = images1;
                }
                if (images2 != "")
                {
                    home.image2 = images2;
                }
                if (images3 != "")
                {
                    home.image3 = images3;
                }
                if (images4 != "")
                {
                    home.image4 = images4;
                }
                if (images5 != "")
                {
                    home.image5 = images5;
                }
                if (images6 != "")
                {
                    home.image6 = images6;
                }
                if (images7 != "")
                {
                    home.image7 = images7;
                }
                if (images8 != "")
                {
                    home.image8 = images8;
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