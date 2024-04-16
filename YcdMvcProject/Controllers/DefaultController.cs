using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace YcdMvcProject.Controllers
{
	public class DefaultController : Controller
	{
		HeadingManager hm = new HeadingManager(new EfHeadingDal());
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Headings() 
		{
			var values = hm.GetHeadings();
			return View(values);
		}
	}
}
