using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;
namespace bdeli.Controllers.WebMaster
{
    public class ContactsController : Controller
    {
        bDeliEntities db = new bDeliEntities();
        // GET: Contacts
        public ActionResult Edit()
        {
            if (Session["Authentication"] != null)
            {
                var rs = db.bD_Contact.Where(st => st.id == 1);
                return View(rs);
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }

        [HttpPost]
        public ActionResult Edit(string email, string sdt, string add)
        {
            if (Session["Authentication"] != null)
            {
                var home = db.bD_Contact.Find(1);
                home.Address = add;
                home.Email = email;
                home.Phone = sdt;
                db.Entry(home).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            else
            {
                return RedirectToAction("Login", "Webmaster");
            }
        }
    }
}