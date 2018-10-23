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
                var rs = db.bD_Booking.Where(s => s.id == 1);
                return View(rs);
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
    }
}