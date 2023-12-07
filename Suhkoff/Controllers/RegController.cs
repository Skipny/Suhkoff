using Microsoft.AspNetCore.Mvc;
using Suhkoff.Data;
using Suhkoff.Models;
using System.Diagnostics;



namespace MPSMWeb.Controllers
{
    public class RegController : Controller
    {
        private readonly ILogger<RegController> _logger;
        private readonly ApplicationContext _context;

        public RegController(ILogger<RegController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }


        public IActionResult Index(RegViewModel input)
        {
                if (ModelState.IsValid){
                    var user = new users{
                        user_name = input.name,
                        age = input.age,
                        e_mail = input.e_mail,
                        user_password = input.Password
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
