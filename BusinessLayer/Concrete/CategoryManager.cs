using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
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
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void AddCategory(Category category)
        {
            _categorydal.Insert(category);
        }

        public void EditCategory(Category category)
        {
            _categorydal.Update(category);
        }

        //GenericRepository<Category> _repo = new GenericRepository<Category>();

        //public IEnumerable<Category> GetAllBL()
        //{
        //    return _repo.GetList();
        //}

        //public void CategoryAddBL(Category category)
        //{
        //    if(category.CategoryName == "" || category.CategoryName.Length <= 3 || category.CategoryDescription == "")
        //    {
        //        throw new Exception("Invalid Value");
        //    }
        //    else
        //    {
        //        _repo.Insert(category);
        //    }
        //}
        public List<Category> GetCategories()
        {
            return _categorydal.GetList();
        }

        public Category GetCategoryByID(int id)
        {
            return _categorydal.Get(x => x.CategoryId == id);
        }

        public void RemoveCategory(Category category)
        {
            _categorydal.Delete(category);
        }
    }
}
