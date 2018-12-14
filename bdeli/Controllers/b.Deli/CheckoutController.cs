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
        public JsonResult AddToCart(bD_Checkout check)
        {
            if(Session["Order"] != null)
            {
                bD_Checkout od = new bD_Checkout();
                od.ID = Session["Order"].ToString();
                od.Name = check.Name;
                od.Phone = check.Phone;
                od.Address = check.Address;
                od.Email = check.Email;
                od.IsChecked = false;
                db.bD_Checkout.Add(od);
                db.SaveChanges();
                return Json(new { Message = "Đặt hàng thành công", status = "200" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Message = "Đặt hàng không thành công. Vui lòng thử lại !", status = "200" }, JsonRequestBehavior.AllowGet);
        }
    }
}