using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        UserProfileManager upm = new UserProfileManager(new EFAuthorDal());
        BlogManager bm = new BlogManager(new EFBlogDal());
        AuthorManager arm = new AuthorManager(new EFAuthorDal());
        Context c = new Context();
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (HttpContext.Session["Mail"]==null)
            {

                return View();
            }
            else
            {

                string mail = (string)Session["Mail"];
                int id = upm.AuthorGetIdByMail(mail);
                var author = arm.GetById(id);
                TempData["Author"] = author;
                return View();
            }
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var blogValues = bm.GetList().ToPagedList(page, 9);
            return PartialView(blogValues);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            var latestPost1 = bm.LatestBlogByCategory(2);
            ViewData["post1"] = latestPost1;
            var latestPost2 = bm.LatestBlogByCategory(6);
            ViewData["post2"] = latestPost2;
            var latestPost3 = bm.LatestBlogByCategory(3);
            ViewData["post3"] = latestPost3;
            var latestPost4 = bm.LatestBlogByCategory(4);
            ViewData["post4"] = latestPost4;
            var mainPost = bm.LatestBlogByCategory(1);
            ViewData["mainpost"] = mainPost;
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            if (HttpContext.Session["Mail"] == null)
            {

                return View();
            }
            else
            {

                string mail = (string)Session["Mail"];
                int id = upm.AuthorGetIdByMail(mail);
                var author = arm.GetById(id);
                TempData["Author"] = author;
                return View();
            }
            
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blog = bm.GetById(id);
            ViewBag.date = blog.BlogDate;
            ViewBag.nameSurname = blog.Author.AuthorName + " " + blog.Author.AuthorSurname;
            return PartialView(blog);
        }
        [AllowAnonymous]
        public PartialViewResult BlogContent(int id)
        {
            var blog = bm.GetById(id);
            return PartialView(blog);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var blogValues = bm.GetBlogsByCategory(id);
            ViewBag.categoryName = blogValues.Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.categoryDescription = blogValues.Select(x => x.Category.CategoryDescription).FirstOrDefault();
            return View(blogValues);
        }
        [AllowAnonymous]
        public ActionResult AdminBlogList()
        {
            var bloges = bm.GetList();
            return View(bloges);
        }
        [AllowAnonymous]
        public ActionResult BlogByAuthor(int id)
        {
            var blogs = bm.GetBlogsByAuthor(id);
            return View(blogs);
        }
        [AllowAnonymous]
        public ActionResult AdminBlogListNew()
        {
            var bloges = bm.GetList();
            return View(bloges);

        }
        
        [HttpGet]
        public ActionResult AddBlog()
        {
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
        
        public ActionResult AddBlog(Blog p)
        {
            p.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var author = (EntityLayer.Concrete.Author)(TempData.Peek("Author"));
            p.AuthorID = author.AuthorID;
            bm.TAdd(p);
            return RedirectToAction("AdminBlogList", "Blog");
        }
       
        public ActionResult DeleteBlog(int id)
        {
            var blog = bm.GetById(id);
            bm.TDelete(blog);
            return RedirectToAction("AdminBlogList", "Blog");
        }
        public ActionResult ChangeStatus(int id)
        {
            var blog = bm.GetById(id);
            bm.AdminBlogStatus(blog);
            return RedirectToAction("AdminBlogList", "Blog");
        }
        [HttpGet]
       
        public ActionResult UpdateBlog(int id)
        {
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
            return RedirectToAction("AdminBlogList", "Blog");
        }
        [AllowAnonymous]
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager(new EFCommentDal());
            var comments = cm.GetCommentByBlog(id);
            return View(comments);
        }
    }
}