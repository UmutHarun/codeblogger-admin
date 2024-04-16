using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace YcdMvcProject.Controllers
{
	public class GalleryController : Controller
	{
		ImageFileManager im = new ImageFileManager(new EfImageFileDal());
		public IActionResult Index()
		{
			var values = im.GetImageFiles();
			return View(values);
		}
	}
}
