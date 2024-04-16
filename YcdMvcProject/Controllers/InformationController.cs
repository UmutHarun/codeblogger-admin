using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace YcdMvcProject.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            HeadingManager hm = new HeadingManager(new EfHeadingDal());
            var CategoryNumber = cm.GetCategories().ToList().Count();
            Category yCategory = new Category()
            {
                CategoryName = "Yazılım",
            };
            var SoftNumber = hm.GetHeadingsByCategory(yCategory).Count();
            var trueStatus = cm.GetCategories().Where(x => x.CategoryStatus == true).Count();
            var falseStatus = cm.GetCategories().Where(x => x.CategoryStatus == false).Count();
            var Diff = Math.Abs(trueStatus - falseStatus);
            //cm.GetCategories().ToList().ForEach(c => { })

            ViewBag.CategoryNumber = CategoryNumber;
            ViewBag.SoftNumber = SoftNumber;
            ViewBag.Diff = Diff;

            return View();
        }
    }
}
