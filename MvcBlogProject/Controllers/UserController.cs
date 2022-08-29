using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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

    public class UserController : Controller
    {
        UserProfileManager upm = new UserProfileManager(new EFAuthorDal());
        AuthorManager ahm = new AuthorManager(new EFAuthorDal());
        BlogManager bm = new BlogManager(new EFBlogDal());
        Context c = new Context();
        public ActionResult Index()
        {
            string mail = (string)Session["Mail"];
            int id = upm.AuthorGetIdByMail(mail);
            var author = ahm.GetById(id);
            TempData["Author"] = author;
            return View();
        }
        public PartialViewResult ProfileLeftPanel()
        {
            var author = (EntityLayer.Concrete.Author)TempData.Peek("Author");
            return PartialView();
        }
        public PartialViewResult NameSurname()
        {
            var author = (EntityLayer.Concrete.Author)TempData.Peek("Author");

            return PartialView();
        }
        public PartialViewResult GetCommentByBlog()
        {
            CommentManager cm = new CommentManager(new EFCommentDal());
            var author = (EntityLayer.Concrete.Author)TempData.Peek("Author");


            var comments = cm.GetCommentListAuthorStatus(author.AuthorID, true);

            return PartialView(comments);


        }
        public PartialViewResult Settings()
        {

            var author = (EntityLayer.Concrete.Author)TempData.Peek("Author");

            return PartialView(author);
        }
        public PartialViewResult MyBlogs()
        {
            var author = (EntityLayer.Concrete.Author)TempData.Peek("Author");
            int id = author.AuthorID;
            var blogs = bm.GetBlogsByAuthor(id);
            return PartialView(blogs);
        }
        [HttpGet]
        public ActionResult ChangeSettings(int id)
        {
            var author = ahm.GetById(id);

            return View(author);
        }
        [HttpPost]
        public ActionResult ChangeSettings(Author p)
        {
            
            
            AuthorUpdateValidator av = new AuthorUpdateValidator();
            ValidationResult results = av.Validate(p);
            if (results.IsValid)
            {                
                   
                        ahm.UpdateMailChange(p);
                        return RedirectToAction("Index", "User");                                                                 
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);

        }
    }
}