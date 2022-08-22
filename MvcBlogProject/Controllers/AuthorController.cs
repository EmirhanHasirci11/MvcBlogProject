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
    public class AuthorController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogDal());
        AuthorManager arm = new AuthorManager(new EFAuthorDal());

        public PartialViewResult AuthorAbout(int id)
        {
            var blog = bm.GetById(id);
            TempData["AuthorID"] = blog.AuthorID;
            return PartialView(blog);
        }
        public PartialViewResult AuthorsPopularPost()
        {
            int authorID = int.Parse(TempData["AuthorID"].ToString());
            var blogs = bm.GetBlogsByAuthor(authorID);
            return PartialView(blogs);
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
            return View(authorValues);
        }
        [HttpPost]
        public ActionResult EditAuthor(Author p)
        {
            arm.TUpdate(p);
            return RedirectToAction("AuthorList","Author");
        }
    }
}