using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace YcdMvcProject.Controllers
{
    //[Authorize]
    public class HeadingController : Controller
    {
        Context c = new Context();
        //HeadingRepository hr { get; set; }
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public IActionResult Index()
        {
            var values = c.Headings.Include(x => x.Category).Include(x => x.Writer).Where(x => x.IsActive == true).ToList();
            //var values = hm.GetHeadings();
            //var values = hr.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddHeading(int? w)
        {
            List<SelectListItem> categoryValues = new List<SelectListItem>();
            cm.GetCategories().ForEach(x =>
            {
                categoryValues.Add
                (
                    new SelectListItem()
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryId.ToString(),
                    }
                );
            });

            ViewBag.WriterId = w;


            //if (TempData["WriterId"] != null)
            //{
            //    int writerId = (int)TempData["WriterId"];
            //    ViewBag.writerId = writerId;
            //}

                

            List<SelectListItem> writerValues = new List<SelectListItem>();
            wm.GetWriters().ForEach(x =>
            {
                writerValues.Add
                (
                    new SelectListItem()
                    {
                        Text = x.WriterName + " " + x.WriterSurname,
                        Value = x.WriterId.ToString(),
                    }
                );
            });

            ViewBag.CategoryValues = categoryValues;
            ViewBag.WriterValues = writerValues;
            return View();
        }

        [HttpPost]
		public IActionResult AddHeading(Heading head)
		{
            //head.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.AddHeading(head);
            return RedirectToAction("Index");
		}

        [HttpGet]
        public IActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryValues = new List<SelectListItem>();
            cm.GetCategories().ForEach(x =>
            {
                categoryValues.Add
                (
                    new SelectListItem()
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryId.ToString(),
                    }
                );
            });
            ViewBag.CategoryValues = categoryValues;

            List<SelectListItem> writerValues = new List<SelectListItem>();
            wm.GetWriters().ForEach(x =>
            {
                writerValues.Add
                (
                    new SelectListItem()
                    {
                        Text = x.WriterName + " " + x.WriterSurname,
                        Value = x.WriterId.ToString(),
                    }
                );
            });
            ViewBag.WriterValues = writerValues;

            var value = hm.GetHeadingById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditHeading(Heading heading)
        {
            hm.EditHeading(heading);
            return RedirectToAction("Index");
            //halledilmedi hata veriyor
        }

        public IActionResult DeleteHeading(int id)
        {
            var value = hm.GetHeadingById(id);
            value.IsActive = false;
            hm.EditHeading(value);
            return RedirectToAction("Index");
        }
	}
}
