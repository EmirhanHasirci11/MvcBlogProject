using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        AboutValidator av = new AboutValidator();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var aboutContent = abm.GetList();
            return View(aboutContent);
        }
        [AllowAnonymous]
        public PartialViewResult Footer()
        {
            var footerAbout = abm.GetById(1);
            return PartialView(footerAbout);
        }
        public PartialViewResult MeetTheTeam()
        {
            return PartialView();
        }
        public ActionResult AboutList()
        {
            var abouts = abm.GetList();
            return View(abouts);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var abouts = abm.GetById(id);
            return View(abouts);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            ValidationResult results = av.Validate(p);
            if (results.IsValid)
            {
                abm.TUpdate(p);

                return RedirectToAction("AboutList", "About");
            }
            else 
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
                return View();
        }
        public ActionResult DeleteAbout(int id)
        {
            var about = abm.GetById(id);
            abm.TDelete(about);
            return RedirectToAction("AboutList","About");
        }
    }
}