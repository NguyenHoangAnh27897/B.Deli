using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;

namespace bdeli.Controllers.WebMaster
{
    public class OrderMasterController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: OrderMaster
        public ActionResult Index()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.bD_Checkout.ToList();
                return View(rs);
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }

        public ActionResult Detaul(string id)
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.bD_Cart.Where(s=>s.ID_Checkout.Equals(id)).ToList();
                return View(rs);
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }

        public ActionResult ConfirmOrder(string orderid)
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.bD_Checkout.Find(orderid);
                rs.IsChecked = true;
                db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
    }
}