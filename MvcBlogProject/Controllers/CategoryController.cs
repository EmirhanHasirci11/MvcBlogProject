using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = cm.GetList();
            return PartialView(categoryValues);
        }
        public ActionResult AdminCategoryList()
        {
             var categories=cm.GetList();
            return View(categories);
        }
    }
}