using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;

namespace bdeli.Controllers.b.Deli
{
    public class CheckoutController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: Checkout
        public ActionResult Index()
        {
            List<AddToCart> lst = new List<AddToCart>();
            AddToCart home = new AddToCart();
            var contact = db.bD_Contact.Find(1);
            home.con = contact;
            lst.Add(home);
            return View(lst);
        }

        [HttpPost]
        public ActionResult AddToCart(string name, string phone, string address, string email)
        {
            if(Session["Order"] != null)
            {
                bD_Checkout od = new bD_Checkout();
                od.ID = Session["Order"].ToString();
                od.Name = name;
                od.Phone = phone;
                od.Address = address;
                od.Email = email;
                od.IsChecked = false;
                db.bD_Checkout.Add(od);
                db.SaveChanges();
                return RedirectToAction("Index", "Gift");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}