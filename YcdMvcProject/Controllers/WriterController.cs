using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YcdMvcProject.Controllers
{
    public class WriterController : Controller
    {
        Context c = new Context();
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator validations = new WriterValidator();
        public IActionResult Index()
        {
            var writers = wm.GetWriters().Where(x => x.isActive == true).ToList();
            return View(writers);
        }

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {
            WriterValidator validations = new WriterValidator();
            ValidationResult results = validations.Validate(writer);
            if(results.IsValid)
            {
                wm.AddWriter(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var value = wm.GetWriterByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer w)
        {

            ValidationResult results = validations.Validate(w);

            if (results.IsValid)
            {
                wm.EditWriter(w);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = wm.GetWriterByID(id);
            writer.isActive = false;
            wm.EditWriter(writer);
            return RedirectToAction("Index");
        }
    }
}
