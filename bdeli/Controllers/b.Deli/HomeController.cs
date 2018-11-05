using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;

namespace bdeli.Controllers
{
    public class HomeController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        public ActionResult Index()
        {
            List<HomeMaster> lst = new List<HomeMaster>();
            HomeMaster home = new HomeMaster();
            //int id = int.Parse(ID);
            var video = db.bD_Video.Where(st => st.id == 1);
            var img = db.bD_Images.Where(st => st.id == 1);
            var sli = db.bD_Slide.Where(st => st.id == 1);
            var introduce = db.bD_Introduce.Where(st => st.id == 1);
            var service = db.bD_Service.Where(st => st.id == 1);
            var contact = db.bD_Contact.Where(st => st.id == 1);
            var time = db.bD_OpenTime.Where(st => st.id == 1);
            var food = db.bD_Food.ToList();
            var tfood = db.bD_FoodType.ToList();
            //home.image = img;
            home.slide = sli;
            home.video = video;
            home.con = contact;
            home.intro = introduce;
            home.ser = service;
            home.image = img;
            home.time = time;
            home.fod = food;
            home.typ = tfood;
            lst.Add(home);
            return View(lst);
           
        }

        [HttpPost]
        public JsonResult save(Booking book)
        {
            if (ModelState.IsValid)
            {
                var bok = new bD_Booking();
                bok.Name = book.name;
                bok.Email = book.email;
                bok.Tel = book.tel;
                bok.DateBooking = book.date.ToString();
                bok.TimeBooking = book.time;
                bok.Amount = book.amount.ToString();
                bok.Note = book.note;
                db.bD_Booking.Add(bok);
                db.SaveChanges();

                return Json(new { status = 201, type = "Success" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 400, type = "Fail" }, JsonRequestBehavior.AllowGet);
        }
    }
}