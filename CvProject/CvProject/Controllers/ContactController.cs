using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models.Entities;
using CvProject.Repositories;

namespace CvProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<Contact> repo = new GenericRepository<Contact>();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            Contact contact = repo.Find(x => x.ID == id);
            repo.TDelete(contact);
            return RedirectToAction("Index");
        }
    }
}