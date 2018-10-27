using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;

namespace bdeli.Controllers.WebMaster
{
    public class FoodMasterController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: FoodMaster
        public ActionResult List()
        {
            if(Session ["Authentication"] != null)
            {
                var list = db.bD_Food.ToList();
                return View(list);
            }
            else
            {
                return RedirectToAction("login", "webmaster");
            }
        }
        public ActionResult Create()
        {
            if(Session ["Authentication"] != null)
            {
                var ltf = db.bD_FoodType.ToList();
            return View(ltf);
            }
            else
            {
                return RedirectToAction("login", "webmaster");
            }
        }
        [HttpPost]
        public ActionResult Create(string tenmonan, string gia, string mota, string loaimonan, HttpPostedFileBase image)
        {
            if (Session["Authentication"] != null)
            {

                string Image = "";
                if (image != null)
                {
                    if (image.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageFood"), fname);
                        image.SaveAs(path);
                        Image += fname;
                    }
                }
                gia = gia.Replace(",", "");
                int price = int.Parse(gia);
                int typequa = int.Parse(loaimonan);
                var lis = new bD_Food();
                lis.Name = tenmonan;
                lis.Price = price;
                lis.Description = mota;
                lis.Type = typequa;
                if (Image != "")
                {
                    lis.Image = Image;
                }
                db.bD_Food.Add(lis);
                db.SaveChanges();

                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Authentication"] != null)
            {
                var de = db.bD_Food.Find(id);
                db.Entry(de).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
        public ActionResult Edit(int id)
        {
            var fd = db.bD_Food.Where(st => st.ID == id);
            var tp = db.bD_FoodType.ToList();
            FoodMaster data = new FoodMaster();
            data.food = fd;
            data.type = tp;
            List <FoodMaster> ls = new List<FoodMaster>();
            ls.Add(data);
            return View(ls);
        }
        [HttpPost]
        public ActionResult Edit(int id, string tenmonan, string gia, string mota, string loaimonan, HttpPostedFileBase image)
        {
            if (Session["Authentication"] != null)
            {

                string Image = "";
                if (image != null)
                {
                    if (image.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(image.FileName);
                        var fname = filename.Replace(" ", "_");
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageFood"), fname);
                        image.SaveAs(path);
                        Image += fname;
                    }
                }
                gia = gia.Replace(",", "");
                int price = int.Parse(gia);
                int loaimon = int.Parse(loaimonan);
                var ls = db.bD_Food.Find(id);
                ls.Name = tenmonan;
                ls.Price = price;
                ls.Description = mota;
                ls.Type = loaimon;
                if (Image != "")
                {
                    ls.Image = Image;
                }
                db.Entry(ls).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
    }
}