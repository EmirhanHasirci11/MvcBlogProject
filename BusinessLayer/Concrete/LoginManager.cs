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
    public class LoginManager : ILoginService
    {
        IAuthorDal _authorDal;
        IAdminDal _adminDal;

        public LoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public LoginManager(IAdminDal adminDal,IAuthorDal authorDal)
        {
            _adminDal = adminDal;
            _authorDal = authorDal;
        }
        

        public LoginManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public Author AuthorLoginCheck(string mail, string password)
        {
            return _authorDal.GetById(x=>x.AuthorMail==mail&&x.AuthorPassword==password);
        }
        public Admin AdminLoginCheck(string name, string password)
        {
            return _adminDal.GetById(x => x.UserName == name && x.Password == password);
        }
    }
}
