using CvProject.Models.Entities;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepository<About> repo = new GenericRepository<About>();

        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(About p)
        {
            var about = repo.Find(x => x.ID == 1);
            about.Name = p.Name;
            about.Surname = p.Surname;
            about.Address = p.Address;
            about.Mail = p.Mail;
            about.Phone = p.Phone;
            about.Description = p.Description;
            about.Image = p.Image;
            repo.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}