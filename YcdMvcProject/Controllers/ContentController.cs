using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YcdMvcProject.Controllers
{
    public class ContentController : Controller
    {
        Context c = new Context();
        ContentManager cm = new ContentManager(new EfContentDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentByHeading(int id)
        {
            //var values = cm.GetListById(id);        
            var values = c.Contents.Include(x => x.Writer).Include(x => x.Heading).Where(x => x.HeadingId == id).ToList();
            return View(values);
        }
    }
}
