using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YcdMvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public IActionResult MyContent(int id)
        {
            /*var values = cm.GetContentsByWriter(id);*/
            var values = c.Contents.Include(x => x.Writer).Include(x => x.Heading).Where(x => x.WriterId == id).ToList();
            return View(values);
        }
    }
}
