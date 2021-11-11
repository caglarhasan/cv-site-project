using CvProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CvProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            CvDBEntities db = new CvDBEntities();
            var values = db.Admin.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["Username"] = values.Username.ToString();
                return RedirectToAction("Index", "Skill");
            }
            else
            {

                return RedirectToAction("Index", "Account");
            }
        }
    }
}