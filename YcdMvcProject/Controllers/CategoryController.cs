using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace YcdMvcProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryList()
        {
            var categoryValues = cm.GetCategories();
            return View(categoryValues);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            CategoryValidator  validationRule = new CategoryValidator();
            ValidationResult result = validationRule.Validate(c);
            if(result.IsValid)
            {
                cm.AddCategory(c);
                return RedirectToAction("CategoryList");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteCategory(int id)
        {
            var cat = cm.GetCategoryByID(id);
            cm.RemoveCategory(cat);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var cat = cm.GetCategoryByID(id);
            return View(cat);
        }
        
        [HttpPost]
        public IActionResult EditCategory(Category cat)
        {
            cm.EditCategory(cat);
            return RedirectToAction("CategoryList");
        }


    }
}
