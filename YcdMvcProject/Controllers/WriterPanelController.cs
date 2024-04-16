using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YcdMvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterHeadings(int id)
        {
            var heading = c.Headings.Include(x => x.Writer).FirstOrDefault(x => x.HeadingId == id);
            TempData["WriterId"] = heading.Writer.WriterId;
            var val = c.Headings.Include(x => x.Writer).Include(x => x.Category).Where(x => x.Writer.WriterId == heading.Writer.WriterId).ToList();
            //BU KODLARIN N KATMANLI MİMARİYE ALINMASI GEREKİYOR , KOD ÇALIŞIYOR AMA BURDA ÇOK KARMAŞIK YAZILMIŞ.
            //var values = hm.GetHeadings().Where(x => x.Writer.WriterId == id).ToList();
            return View(val);
        }
    }
}
