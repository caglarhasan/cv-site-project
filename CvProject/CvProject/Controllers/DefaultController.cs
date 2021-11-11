using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models.Entities;

namespace CvProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        CvDBEntities db = new CvDBEntities();
        public ActionResult Index()
        {
            var values = db.About.ToList();
            return View(values);
        }

        public PartialViewResult Experience()
        {
            var values = db.Experience.ToList();
            return PartialView(values);
        }

        public PartialViewResult Education()
        {
            var values = db.Education.ToList();
            return PartialView(values);
        }

        public PartialViewResult Skill()
        {
            var values = db.Skill.ToList();
            return PartialView(values);
        }

        public PartialViewResult Interest()
        {
            var values = db.Interest.ToList();
            return PartialView(values);
        }

        public PartialViewResult Certification()
        {
            var values = db.Certification.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Contact(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }
    }
}