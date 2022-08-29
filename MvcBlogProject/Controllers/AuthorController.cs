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
using System.Web.Security;

namespace MvcBlogProject.Controllers
{
    public class AuthorController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogDal());
        AuthorManager arm = new AuthorManager(new EFAuthorDal());
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var blog = bm.GetById(id);
            TempData["AuthorID"] = blog.AuthorID;
            return PartialView(blog);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorsPopularPost()
        {
            int authorID = int.Parse(TempData.Peek("AuthorID").ToString());
            var blogs = bm.GetBlogsByAuthor(authorID);
            return PartialView(blogs);
        }
        [AllowAnonymous]
        public ActionResult AuthorProfile(int id)
        {
            var author = arm.GetById(id);            
            return View(author);
        }

        public ActionResult AuthorList()
        {
            var authorValues = arm.GetList();
            return View(authorValues);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            if (p.AuthorImage == null)
            {
                p.AuthorImage = "/Images/user.png";

                arm.TAdd(p);
            }
            else
            {
                arm.TAdd(p);
            }
            return RedirectToAction("AuthorList", "Author");
        }

        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            var authorValues = arm.GetById(id);
            TempData["Authorid"] = authorValues.AuthorID;
            TempData["Authormail"] = authorValues.AuthorMail;
            return View(authorValues);
        }
        [HttpPost]


        public ActionResult EditAuthor(Author p)
        {
            int id = Convert.ToInt32(TempData["Authorid"]);
            string mail = TempData["Authormail"].ToString();
            AuthorUpdateValidator av = new AuthorUpdateValidator();
            ValidationResult results = av.Validate(p);
            if (results.IsValid)
            {
                arm.TUpdate(p);
                return RedirectToAction("AuthorList", "Author");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}