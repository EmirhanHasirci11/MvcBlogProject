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

    public class MailSubscribeController : Controller
    {
        SubscribeMailManager smm = new SubscribeMailManager(new EFSubscribeMailDal());

        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            SubscribeMailValidator validationRules = new SubscribeMailValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                smm.TAdd(p);

                return PartialView();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return PartialView();
            }
            
        }
    }
}