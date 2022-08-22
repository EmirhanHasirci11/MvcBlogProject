using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            var aboutContent = abm.GetList();
            return View(aboutContent);
        }
        public PartialViewResult Footer()
        {
            var footerAbout = abm.GetById(1);
            return PartialView(footerAbout);
        }
        public PartialViewResult MeetTheTeam()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var abouts = abm.GetList();
            return View(abouts);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.TUpdate(p);
            return RedirectToAction("UpdateAboutList", "About");
        }
    }
}