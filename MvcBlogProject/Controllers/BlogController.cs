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
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult BlogList(int page =1)
        {
            var blogValues = bm.GetList().ToPagedList(page,3);
            return PartialView(blogValues);
        }
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
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }       

        public ActionResult BlogDetails()
        {
            
            return View();
        }
        public PartialViewResult BlogCover(int id)
        {
            var blog = bm.GetById(id);
            ViewBag.date = blog.BlogDate;
            ViewBag.nameSurname = blog.Author.AuthorName + " " + blog.Author.AuthorSurname;
            return PartialView(blog);
        }
        public PartialViewResult BlogContent(int id)
        {                      
            var blog = bm.GetById(id);
            return PartialView(blog);
        }
        public ActionResult BlogByCategory(int id)
        {
            var blogValues = bm.GetBlogsByCategory(id);
            ViewBag.categoryName = blogValues.Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.categoryDescription = blogValues.Select(x => x.Category.CategoryDescription).FirstOrDefault();
            return View(blogValues);
        }
        public ActionResult AdminBlogList()
        {
            var bloges = bm.GetList();
            return View(bloges);
        }
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
            p.AuthorID = 1;
            bm.TAdd(p);
            return RedirectToAction("AdminBlogList","Blog");
        }
        public ActionResult DeleteBlog(int id)
        {
            var blog = bm.GetById(id);
            bm.TDelete(blog);
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
            var blog= bm.GetById(id);
            return View(blog);
        } 
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.TUpdate(p);
            return RedirectToAction("AdminBlogList","Blog");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager(new EFCommentDal());
            var comments = cm.GetCommentByBlog(id);
            return View(comments);
        }
    }
}