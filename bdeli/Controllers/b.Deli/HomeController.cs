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
            //home.image = img;
            home.slide = sli;
            home.video = video;
            home.con = contact;
            home.intro = introduce;
            home.ser = service;
            home.image = img;
            home.time = time;
            lst.Add(home);
            return View(lst);
           
        }

        [HttpPost]
        public ActionResult save(string name, string email, DateTime date, string time, int amount, string note)
        {
            try
            {
                var book = new bD_Booking();
                book.Name = name;
                book.Email = email;
                book.DateBooking = date.ToString();
                book.TimeBooking = time;
                book.Amount = amount.ToString();
                book.Note = note;
                db.bD_Booking.Add(book);
                db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Error");
            }
           
        }
    }
}