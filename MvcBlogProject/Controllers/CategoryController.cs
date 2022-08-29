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
    
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());      
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = cm.GetList();
            return PartialView(categoryValues);
        }
        [AllowAnonymous]
        public ActionResult BlogCategoryList()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
        public ActionResult AdminCategoryList()
        {
             var categories=cm.GetList();
            return View(categories);
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = cm.GetById(id);
            cm.TDelete(category);
            return RedirectToAction("AdminCategoryList", "Category");
        }
        public PartialViewResult AddCategoryPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = cm.GetById(id);
            return View(category);

        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            cm.TUpdate(p);
            return RedirectToAction("AdminCategoryList", "Category");

        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
            [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            cm.TAdd(c);
            return RedirectToAction("AdminCategoryList", "Category");
        }
    }
}