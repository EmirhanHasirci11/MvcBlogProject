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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void TAdd(Category t)
        {
            t.CategoryStatus = true;
            _categoryDal.Insert(t);

        }

        public void TDelete(Category t)
        {
            if (t.CategoryStatus == true)
            {
                t.CategoryStatus = false;
            }
            else
            {
                t.CategoryStatus = true;
            }
            _categoryDal.Update(t);          
        }

        public void TUpdate(Category t)
        {
            t.CategoryStatus = true;
            _categoryDal.Update(t);
        }
    }
}
