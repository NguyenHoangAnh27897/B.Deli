using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;
namespace bdeli.Controllers.WebMaster
{
    public class BookingController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: Booking
        public ActionResult List()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.bD_Booking.ToList();
                return View(rs);
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
                var typ = db.bD_Booking.Find(id);
                db.Entry(typ).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
    }
}