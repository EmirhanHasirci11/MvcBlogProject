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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void AdminBlogStatus(Blog p)
        {
            if (p.BlogStatus == false)
            {
                p.BlogStatus = true;
            }
            else
            {
                p.BlogStatus = false;
            }
            _blogDal.Update(p);
        }

        public void BlogDeleteAuthor(Blog blog)
        {
            blog.BlogStatus = false;
            _blogDal.Update(blog);
        }

        public List<Blog> GetBlogsByAuthor(int authorID)
        {
            return _blogDal.List(x=>x.AuthorID==authorID&&x.BlogStatus==true);
        }

        public List<Blog> GetBlogsByCategory(int categoryID)
        {
            return _blogDal.List(x=>x.CategoryID==categoryID);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(x => x.BlogID == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public Blog LatestBlogByCategory(int categoryID)
        {
            return GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == categoryID).FirstOrDefault();
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
        
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}
