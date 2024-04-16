using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

        void AddCategory(Category category);

        Category GetCategoryByID(int id);

        void RemoveCategory(Category category);    

        void EditCategory(Category category);
    }
}
