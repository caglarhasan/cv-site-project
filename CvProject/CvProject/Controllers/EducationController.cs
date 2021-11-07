using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models.Entities;
using CvProject.Repositories;

namespace CvProject.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository repo = new EducationRepository();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(Education p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            Education education = repo.Find(x => x.ID == id);
            repo.TDelete(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetEducation(int id)
        {
            Education education = repo.Find(x => x.ID == id);
            return View(education);
        }

        [HttpPost]
        public ActionResult GetEducation(Education p)
        {
            Education education = repo.Find(x => x.ID == p.ID);
            education.Title = p.Title;
            education.Subtitle = p.Subtitle;
            education.Description = p.Description;
            education.Date = p.Date;
            repo.TUpdate(education);
            return RedirectToAction("Index");
        }
    }
}