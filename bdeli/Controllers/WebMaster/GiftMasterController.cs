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
    public class GiftMasterController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: GiftMaster
        public ActionResult List(int? page = 1)
        {
            if (Session["Authentication"] != null)
            {
                int pageSize = 7;
                int pageNumber = (page ?? 1);
                var lst = db.bD_Gift.ToList();
                return View(lst.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
        public ActionResult Create()
        {
            if (Session["Authentication"] != null)
            {
                var typ = db.bD_TypeGift.ToList();
                return View(typ);
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
        [HttpPost]
        public ActionResult Create(string namgift, string gia, string mota, string loaigift, HttpPostedFileBase image)
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
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageGift"), fname);
                        image.SaveAs(path);
                        Image += fname;
                    }
                }

                int typequa = int.Parse(loaigift);
                var ls = new bD_Gift();
                ls.Name = namgift;
                if (gia != "")
                {
                    gia = gia.Replace(",", "");
                    int price = int.Parse(gia);
                    ls.Price = price;
                }
                ls.Description = mota;
                ls.Type = typequa;
                if (Image != "")
                {
                    ls.Image = Image;
                }
                db.bD_Gift.Add(ls);
                db.SaveChanges();

                return RedirectToAction("list", "giftmaster");
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
                var typ = db.bD_Gift.Find(id);
                db.Entry(typ).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
        public ActionResult Edit(int id)
        {
            var gif = db.bD_Gift.Where(st => st.ID == id);
            var typ = db.bD_TypeGift.ToList();
            GiftMaster data = new GiftMaster();
            data.gift = gif;
            data.type = typ;
            List<GiftMaster> ls = new List<GiftMaster>();
            ls.Add(data);
            return View(ls);
        }
        [HttpPost]
        public ActionResult Edit(int id, string namgift, string gia, string mota, string loaigift, HttpPostedFileBase image)
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
                        var path = Path.Combine(Server.MapPath("~/Images/b.Deli/imageGift"), fname);
                        image.SaveAs(path);
                        Image += fname;
                    }
                }
                int typequa = int.Parse(loaigift);
                var ls = db.bD_Gift.Find(id);
                ls.Name = namgift;
                if (gia != "")
                {
                    gia = gia.Replace(",", "");
                    int price = int.Parse(gia);
                    ls.Price = price;
                }
                ls.Description = mota;
                ls.Type = typequa;
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