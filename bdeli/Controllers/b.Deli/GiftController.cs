using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using bdeli.Models;

namespace bdeli.Controllers.b.Deli
{
    public class GiftController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: Gift
        public ActionResult Index()
        {
            List<Gift> lst = new List<Gift>();
            Gift home = new Gift();
            //int id = int.Parse(ID);
            var contact = db.bD_Contact.Where(st => st.id == 1);
            var gift = db.bD_Gift.ToList();
            var typ = db.bD_TypeGift.ToList();
            home.gft = gift;
            home.tpe = typ;
            //home.image = img;
            home.con = contact;
            lst.Add(home);
            return View(lst);
        }

        public JsonResult AddCart(int? id, Cart cart)
        {
            var data = db.bD_Gift.FirstOrDefault(x => x.ID == id);
            return Json(new { status = 201, type = "GET", data = data }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]

        public JsonResult AddToCart()
        {
            var resolveRequest = HttpContext.Request;
            List<Cart> cart = new List<Cart>();
            resolveRequest.InputStream.Seek(0, SeekOrigin.Begin);
            string jsonString = new StreamReader(resolveRequest.InputStream).ReadToEnd();
            if (jsonString != null)
            {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    cart = (List<Cart>)serializer.Deserialize(jsonString, typeof(List<Cart>));
            }
            Session["Order"] = getGUID();
            if (cart != null)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    bD_Cart rc = new bD_Cart();
                    rc.ID = getGUID();
                    rc.ID_Checkout = Session["Order"].ToString();
                    rc.FoodName = cart[i].Name;
                    rc.Quantity = int.Parse(cart[i].Quantity);
                    rc.Price = int.Parse(cart[i].Price);
                    rc.Total = int.Parse(cart[i].Price) * int.Parse(cart[i].Quantity);
                    db.bD_Cart.Add(rc);
                    db.SaveChanges();
                }
                return Json(new { msg = "Thành công", status = "200" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { msg = "Thất bại", status = "500" }, JsonRequestBehavior.AllowGet);
            }
        }

        //generate ra một id mới
        public static string getGUID()
        {
            string rs = "";
            char replace = '-';
            char to = '_';
            try
            {
                rs = Guid.NewGuid().ToString();
                rs = rs.Replace(replace, to);
            }
            catch (Exception ex)
            {
                string mess = ex.Message.ToString();
            }
            return rs;
        }
    }
}