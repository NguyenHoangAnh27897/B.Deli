using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}