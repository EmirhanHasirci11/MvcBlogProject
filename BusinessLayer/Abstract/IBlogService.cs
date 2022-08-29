using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        Blog LatestBlogByCategory(int categoryID);
        void AdminBlogStatus(Blog p);
        
        List<Blog> GetBlogsByAuthor(int authorID);
        List<Blog> GetBlogsByCategory(int categoryID);
        void BlogDeleteAuthor(Blog blog);
    }
}
