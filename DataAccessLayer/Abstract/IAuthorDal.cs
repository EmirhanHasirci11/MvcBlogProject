using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IAuthorDal:IRepository<Author>
    {
         void UpdateWithoutMail(Author p);
        
            
        
    }
}
