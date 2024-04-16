using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace YcdMvcProject.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReceivedMessages()
        {
            var values = mm.GetMessages();
            //var unread = mm.GetMessages().Where(x => x.Read == false).Count();
            //ViewBag.UnreadCount = unread;
            return View(values);
        }

        public IActionResult SentMessages()
        {
            var values = mm.SentMessages().Where(x => x.IsSent == true).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewMessage() 
        {
            return View();
        }

        public IActionResult MessageDetails(int id)
        {
            var msg = mm.GetMessageByID(id);
            msg.Read = true;
            mm.EditMessage(msg);
            return View(msg);
        }

        [HttpPost]
        public IActionResult AddDraftMessage(Message m)
        {
            m.MessageDate = DateTime.Now;
            m.IsSent = false;
            m.SenderMail = "admin@gmail.com";
            mm.AddMessage(m);
            return RedirectToAction("DraftMessages");
        }

        public IActionResult DraftMessages()
        {
            var values = mm.SentMessages().Where(x => x.IsSent == false).ToList();
            return View(values);
        }
    }
}
