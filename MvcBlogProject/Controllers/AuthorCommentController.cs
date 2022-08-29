using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    
    public class AuthorCommentController : Controller
    {
        UserProfileManager upm = new UserProfileManager(new EFAuthorDal());
        CommentManager cm = new CommentManager(new EFCommentDal());
        public ActionResult Comments()
        {
            string mail = (string)Session["Mail"];
            var authorId = upm.AuthorGetIdByMail(mail);
            TempData["authorId"] = authorId;
            var comments = cm.GetCommentListByAuthorID(authorId);
            return View(comments);
        }
        public ActionResult CommentsTrue()
        {
            int id = Convert.ToInt32((TempData.Peek("authorId")));
            var comments = cm.GetCommentListAuthorStatus(id, true);
            return View(comments);
        }
        public ActionResult CommentsFalse()
        {
            int id = Convert.ToInt32((TempData.Peek("authorId")));
            var comments = cm.GetCommentListAuthorStatus(id, false);
            return View(comments);
        }
        public ActionResult BlogComments(int id)
        {
            var comments = cm.GetCommentByBlog(id);
            return View(comments);
        }
    }
}