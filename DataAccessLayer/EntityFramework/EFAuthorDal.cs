using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAuthorDal : Repository<Author>, IAuthorDal
    {
        public void UpdateWithoutMail(Author p)
        {
            Context c = new Context();
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            updatedEntity.Property(x => x.AuthorMail).IsModified = false;           
            c.SaveChanges();
        }
    }
}
