using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using Suhkoff.Data;


namespace Suhkoff.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ApplicationContext _context;
        public LoginController(ILogger<LoginController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x=>x.e_mail == email && x.user_password == password);
            if (user != null){
                var claims = new List<Claim> { 
                    new Claim("Id", user.user_id.ToString()),
                    new Claim(ClaimTypes.Name, user.e_mail),
                    new Claim(ClaimTypes.Role, "user")

                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookie");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {   
            return View();
        }
    }
}