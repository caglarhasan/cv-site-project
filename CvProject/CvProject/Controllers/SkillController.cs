using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models.Entities;
using CvProject.Repositories;

namespace CvProject.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        GenericRepository<Skill> repo = new GenericRepository<Skill>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
    }
}