using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models.Entities;
using CvProject.Repositories;

namespace CvProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admin> repo = new GenericRepository<Admin>();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            Admin admin = repo.Find(x => x.ID == id);
            repo.TDelete(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            Admin admin = repo.Find(x => x.ID == id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult GetAdmin(Admin p)
        {
            Admin admin= repo.Find(x => x.ID == p.ID);
            admin.Username = p.Username;
            admin.Password = p.Password;
            repo.TUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}