using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LoginManager lm = new LoginManager(new EFAdminDal(),new EFAuthorDal());
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author p, string ReturnUrl)
        {
            var authorInfo = lm.AuthorLoginCheck(p.AuthorMail, p.AuthorPassword);
            if (authorInfo != null)
            {
                FormsAuthentication.SetAuthCookie(authorInfo.AuthorMail, false);
                Session["Mail"] = authorInfo.AuthorMail;
                if (string.IsNullOrEmpty(ReturnUrl))
                {

                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Hata! Yanlış kullanıcı maili veya şifre";
                return RedirectToAction("AuthorLogin");
            }

        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p,string ReturnUrl)
        {
            var adminInfo = lm.AdminLoginCheck(p.UserName, p.Password);
            if (adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.UserName, false);
                Session["UserName"] = adminInfo.UserName;
                if (string.IsNullOrEmpty(ReturnUrl))
                {

                    return RedirectToAction("AdminBlogListNew", "Blog");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Hata! Yanlış kullanıcı maili veya şifre";
                return RedirectToAction("AdminLogin");
            }
           
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Blog");
        }
    }
}