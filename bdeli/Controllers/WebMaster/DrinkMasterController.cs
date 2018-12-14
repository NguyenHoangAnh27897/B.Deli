using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;
using PagedList;
using PagedList.Mvc;

namespace bdeli.Controllers.WebMaster
{
    public class DrinkMasterController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: FoodMaster
        public ActionResult List(int? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var list = db.bD_Drink.ToList();
                return View(list.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("login", "webmaster");
            }
        }
        public ActionResult Create()
        {
            if (Session["Authentication"] != null)
            {
                var ltf = db.bD_DrinkType.ToList();
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
                int typequa = int.Parse(loaimonan);
                var lis = new bD_Drink();
                lis.Name = tenmonan;
                if (gia != "")
                {
                    gia = gia.Replace(",", "");
                    int price = int.Parse(gia);
                    lis.Price = price;
                }
                lis.Description = mota;
                lis.Type = typequa;
                if (Image != "")
                {
                    lis.Image = Image;
                }
                db.bD_Drink.Add(lis);
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
                var de = db.bD_Drink.Find(id);
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
            var fd = db.bD_Drink.Where(st => st.ID == id);
            var tp = db.bD_DrinkType.ToList();
            DrinkMaster data = new DrinkMaster();
            data.drink = fd;
            data.type = tp;
            List<DrinkMaster> ls = new List<DrinkMaster>();
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
                int loaimon = int.Parse(loaimonan);
                var ls = db.bD_Drink.Find(id);
                ls.Name = tenmonan;
                if (gia != "")
                {
                    gia = gia.Replace(",", "");
                    int price = int.Parse(gia);
                    ls.Price = price;
                }
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