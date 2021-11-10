using CvProject.Models.Entities;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest
        InterestRepository repo = new InterestRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddInterest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInterest(Interest p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInterest(int id)
        {
            Interest interest = repo.Find(x => x.ID == id);
            repo.TDelete(interest);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetInterest(int id)
        {
            Interest interest = repo.Find(x => x.ID == id);
            return View(interest);
        }
        [HttpPost]
        public ActionResult GetInterest(Interest p)
        {
            Interest interest = repo.Find(x => x.ID == p.ID);
            interest.Description = p.Description;
            repo.TUpdate(interest);
            return RedirectToAction("Index");
        }
    }
}