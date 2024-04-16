using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace YcdMvcProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public IActionResult Index()
        {
            var values = abm.GetAbouts();
            return View(values);
        }

        //[HttpGet]
        //public IActionResult AddAbout()
        //{
        //    return View();
        //}

        public PartialViewResult AddAbout()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddAbout(About a)
        {
            abm.AddAbout(a);    
            return RedirectToAction("Index");
        }
    }
}
