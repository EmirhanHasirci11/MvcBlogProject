using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> GetCommentByBlog(int id);
        bool CommentSenderIsAuthor(int id);
        void TAdd(Comment c,int blogID,int authorID,string mail);
        List<Comment> GetCommentListStatus(bool status);
        List<Comment> GetCommentListByAuthorID(int id);
        List<Comment> GetCommentListAuthorStatus(int authorId, bool status);


    }
}
