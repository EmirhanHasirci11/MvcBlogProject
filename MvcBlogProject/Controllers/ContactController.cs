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
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact p)
        {
            cm.TAdd(p);
            return View();
        }
        public PartialViewResult MessageSidebar()
        {
            return PartialView();
        }
        public ActionResult Inbox()
        {
            var contact= cm.GetList();
            return View(contact);
        }
        public ActionResult MessageDetails(int id)
        {
            var message = cm.GetById(id);
            return View(message);
        }
    }
}