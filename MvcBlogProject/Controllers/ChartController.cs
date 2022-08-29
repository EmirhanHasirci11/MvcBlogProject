using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcBlogProject.Models.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class ChartController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BlogJson()
        {
            return Json(BlogChart(), JsonRequestBehavior.AllowGet);
        }
        public List<BlogRatings> BlogChart()
        {
            List<BlogRatings> list = new List<BlogRatings>();
            using (var c= new Context()){
                list = c.Blogs.Select(x => new BlogRatings
                {
                    BlogRating = 12,
                    BlogTitle = x.BlogTitle
                }).ToList();
            }
            return list;
        }
    }
}