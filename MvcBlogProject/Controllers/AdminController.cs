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
    [AllowAnonymous]
    public class AdminController : Controller
    {
        AdminManager adm = new AdminManager(new EFAdminDal());
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            AdminValidator av = new AdminValidator(adm.GetList());
            ValidationResult result = av.Validate(p);
            if (result.IsValid)
            {
                p.UserName.ToLower();
                adm.TAdd(p);
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                foreach(var item in result.Errors)
                {

                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }

            }
                return View();
        }
    }
}