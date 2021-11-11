using CvProject.Models.Entities;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    [Authorize]
    public class CertificationController : Controller
    {
        // GET: Certification
        CertificationRepository repo = new CertificationRepository();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCertification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertification(Certification p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertification(int id)
        {
            Certification certification = repo.Find(x => x.ID == id);
            repo.TDelete(certification);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetCertification(int id)
        {
            Certification certification = repo.Find(x => x.ID == id);
            return View(certification);
        }
        [HttpPost]
        public ActionResult GetCertification(Certification p)
        {
            Certification certification = repo.Find(x => x.ID == p.ID);
            certification.Title = p.Title;
            certification.Subtitle = p.Subtitle;
            certification.Date = p.Date;
            repo.TUpdate(certification);
            return RedirectToAction("Index");
        }
    }
}