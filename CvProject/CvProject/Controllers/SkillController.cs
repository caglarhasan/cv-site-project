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
        //GenericRepository<Skill> repo = new GenericRepository<Skill>();
        SkillRepository repo = new SkillRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        } 

        public ActionResult DeleteSkill(int id)
        {
            Skill skill = repo.Find(x => x.ID == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSkill(int id)
        {
            Skill skill = repo.Find(x => x.ID == id);
            return View(skill);
        }

        [HttpPost]
        public ActionResult GetSkill(Skill p)
        {
            Skill skill = repo.Find(x => x.ID == p.ID);
            skill.Ability = p.Ability;
            skill.Progress = p.Progress;
            repo.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}