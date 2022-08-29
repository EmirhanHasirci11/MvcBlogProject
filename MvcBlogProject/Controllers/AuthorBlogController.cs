using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    
    public class AuthorBlogController : Controller
    {
        UserProfileManager upm = new UserProfileManager(new EFAuthorDal());
        BlogManager bm = new BlogManager(new EFBlogDal());
        AuthorManager arm = new AuthorManager(new EFAuthorDal());

        Context c = new Context();
        public ActionResult MyBlogs()
        {
            string mail = (string)Session["Mail"];
            int id = upm.AuthorGetIdByMail(mail);
            var author = arm.GetById(id);
            TempData["Author"] = author;
            var blogs = bm.GetBlogsByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var author = (EntityLayer.Concrete.Author)TempData.Peek("Author");
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.categoryValues = values;
            var blog = bm.GetById(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.TUpdate(p);
            return RedirectToAction("MyBlogs", "AuthorBlog");
        }
        [HttpGet]
        public ActionResult AddBlog()
        {
            var author = (EntityLayer.Concrete.Author)TempData.Peek("Author");
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.categoryValues = values;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddBlog(Blog p)
        {
            p.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var author = (EntityLayer.Concrete.Author)(TempData.Peek("Author"));
            p.AuthorID = author.AuthorID;
            bm.TAdd(p);
            return RedirectToAction("MyBlogs", "User");
        }
        public ActionResult DeleteBlog(int id)
        {
            var blog = bm.GetById(id);
            bm.BlogDeleteAuthor(blog);
            return RedirectToAction("MyBlogs", "AuthorBlog");
        }


    }
}