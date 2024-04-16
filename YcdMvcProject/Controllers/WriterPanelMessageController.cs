using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace YcdMvcProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReceivedMessages()
        {
            var values = mm.GetMessages();
            return View(values);
        }

        [HttpGet]
        public IActionResult ReceivedMessageDetails(int id)
        {
            var values = mm.GetMessages().Where(x => x.MessageId == id).FirstOrDefault();
            return View(values);
        }

        public IActionResult MessageListBoxPartial()
        {
            return PartialView();
        }
    }
}
