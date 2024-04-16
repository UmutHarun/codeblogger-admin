using Microsoft.AspNetCore.Mvc;

namespace YcdMvcProject.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page403()
        {
            return View();
        }

        public IActionResult Page404()
        {
            return View();
        }
    }
}
