using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bdeli.Models;

namespace bdeli.Controllers.WebMaster
{
    public class AccountMasterController : Controller
    {
		bDeliEntities db = new bDeliEntities();
        // GET: AccountMaster
        public ActionResult Edit()
        {
			if(Session["Authentication"] != null)
			{
				var ls = db.bD_Account.Where(st => st.id == 1);
				return View();
			}
			else
			{
				return RedirectToAction("Login", "Webmaster");
			}
			
        }

		[HttpPost]
		public ActionResult Edit(string id, string oldpassword, string newpassword, string confirmpassword)
		{
			if (Session["Authentication"] != null)
			{
				//int ID = int.Parse(id);
				var lst = db.bD_Account.Find(1);
				if (lst.Password.Equals(oldpassword))
				{
					if(newpassword == confirmpassword)
					{
						lst.Password = newpassword;
						db.Entry(lst).State = System.Data.Entity.EntityState.Modified;
						db.SaveChanges();
					}
				}
				return RedirectToAction("Edit");
			}
			else
			{
				return RedirectToAction("Login", "Webmaster");
			}
		}
    }
}