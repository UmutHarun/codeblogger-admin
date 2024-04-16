using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace YcdMvcProject.Controllers
{
    
    public class AccountController : Controller
    {
		Context c = new Context();
		public IActionResult Index()
        {
            return View();
        }

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
        public async Task<IActionResult> Login(Admin a)
        {
			

			if (ModelState.IsValid)
            {
                var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUsername == a.AdminUsername && x.AdminPassword == a.AdminPassword);
				if(adminUserInfo != null)
                {
					var claims = new List<Claim>()
				    {
					    new Claim(ClaimTypes.Name , a.AdminUsername)
				    };

					var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

					return RedirectToAction("Index","Heading");
				}
			}
            return View();
        }

        public IActionResult Register()
        {
            return View();  
        }

        [AllowAnonymous]
        [HttpGet]
		public IActionResult WriterLogin()
		{
			return View();
		}

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> WriterLogin(Writer w)
        {
            var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword == w.WriterPassword);
            if (writerUserInfo != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim("Mail" , w.WriterMail)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                Context c = new Context();
                var val = c.Writers.Where(x => x.WriterMail == w.WriterMail).FirstOrDefault();

				return RedirectToAction("MyContent", "WriterPanelContent", new { id = val.WriterId });
			}
            return View();
        }
    }
}
