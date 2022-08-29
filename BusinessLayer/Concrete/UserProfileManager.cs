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
    public class UserProfileManager : IUserProfileService
    {
        IAuthorDal _authorDal;

        public UserProfileManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public int AuthorGetIdByMail(string mail)
        {
            return _authorDal.GetById(x=>x.AuthorMail==mail).AuthorID;
        }
    }
}
