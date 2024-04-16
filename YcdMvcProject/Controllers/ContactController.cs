using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace YcdMvcProject.Controllers
{
    public class ContactController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        public IActionResult Index()
        {
            var values = cm.GetContacts();
            return View(values);
        }

        public IActionResult ContactDetails(int id)
        {
            var value = cm.GetContactByID(id);
            return View(value);
        }

        public IActionResult ContactSideboxPartial() 
        {
            //var unread = mm.GetUnreadCount();
            Context c = new Context();
            var unread = c.Messages.Count(x => x.Read == false);
            ViewBag.UnreadCount = "Frghergerg";
            return PartialView();
        }
    }
}
