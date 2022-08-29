using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public bool CommentSenderIsAuthor(int id)
        {
            if (_commentDal.GetById(x => x.AuthorID == id) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(x => x.CommentID == id);
        }

        public List<Comment> GetCommentByBlog(int id)
        {
            return _commentDal.List(x => x.BlogID == id);
        }

       

        public List<Comment> GetCommentListByAuthorID(int id)
        {
            return _commentDal.List(x => x.AuthorID == id);
        }

        public List<Comment> GetCommentListStatus(bool status)
        {
            return _commentDal.List(x => x.CommentStatus == status);
        }
        public List<Comment> GetCommentListAuthorStatus(int authorId,bool status)
        {
            return _commentDal.List(x => x.CommentStatus == status &&x.AuthorID==authorId);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public void TAdd(Comment t)
        {
            t.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            if (t.CommentStatus == true)
            {
                t.CommentStatus = false;
            }
            else
            {
                t.CommentStatus = true;
            }
            _commentDal.Update(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }

        public void TAdd(Comment c, int blogID, int authorID, string mail)
        {
            c.BlogID = blogID;
            c.AuthorID = authorID;
            c.CommentMail = mail;
            c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _commentDal.Insert(c);
        }
    }
}
