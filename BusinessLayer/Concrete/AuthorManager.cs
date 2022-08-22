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
    public class AuthorManager:IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }       
        public Author GetById(int id)
        {
            return _authorDal.GetById(x => x.AuthorID == id);
        }

        public List<Author> GetList()
        {
            return _authorDal.List();
        }

        public void TAdd(Author t)
        {
            _authorDal.Insert(t);
        }

        public void TDelete(Author t)
        {
            _authorDal.Delete(t);
        }

        public void TUpdate(Author t)
        {
            _authorDal.Update(t);
        }
    }
}
