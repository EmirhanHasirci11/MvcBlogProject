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
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EFCommentDal());
        UserProfileManager upm = new UserProfileManager(new EFAuthorDal());

        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var comments = cm.GetCommentByBlog(id);
            ViewBag.commentCount = comments.Count();

            return PartialView(comments);
        }
        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult LeaveComment(int id)
        {
            
            TempData["BlogID"] = id;
            ViewBag.BlogID = id;
            return PartialView();
        }
        [HttpPost]
        
        public RedirectToRouteResult LeaveComment(Comment c)
        {

            int blogID = int.Parse(TempData.Peek("BlogID").ToString());
            string mail = (string)Session["Mail"];
            int id = upm.AuthorGetIdByMail(mail);
            c.CommentStatus = true;
            cm.TAdd(c,blogID,id,mail);
            return RedirectToAction("BlogDetails/" + c.BlogID, "Blog");
        }
        public ActionResult AdminCommentListTrue()
        {
            var comments = cm.GetCommentListStatus(true);
            return View(comments);
        }
        public ActionResult AdminCommentListFalse()
        {
            var comments = cm.GetCommentListStatus(false);
            return View(comments);
        }
        public ActionResult ChangeStatusToFalse(int id)
        {
            var comment = cm.GetById(id);
            cm.TDelete(comment);
            return RedirectToAction("AdminCommentListTrue", "Comment");
        }
        public ActionResult ChangeStatusToTrue(int id)
        {
            var comment = cm.GetById(id);
            cm.TDelete(comment);
            return RedirectToAction("AdminCommentListFalse", "Comment");
        }
    }
}