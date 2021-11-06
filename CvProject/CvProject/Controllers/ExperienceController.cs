using CvProject.Models.Entities;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(Experience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            Experience experience = repo.Find(x => x.ID == id);
            repo.TDelete(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            Experience experience = repo.Find(x => x.ID == id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult GetExperience(Experience p)
        {
            Experience experience = repo.Find(x => x.ID == p.ID);
            experience.Title = p.Title;
            experience.Subtitle = p.Subtitle;
            experience.Date = p.Date;
            experience.Description = p.Description;
            repo.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}