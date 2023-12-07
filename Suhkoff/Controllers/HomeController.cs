using Microsoft.AspNetCore.Mvc;
using Suhkoff.Data;
using Suhkoff.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace Suhkoff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }

        public IActionResult Index(int? filter_id)
        {
            var viewModel = new HomeViewModel();
            viewModel.Users = _context.Users.ToList();
            if (filter_id != null)
            {
                viewModel.Tasks = _context.Tasks.Where(x => x.users.user_id == filter_id).ToList();
            }
            else
            {
                viewModel.Tasks = _context.Tasks.ToList();
            }
            return View(viewModel);
        }

        public IActionResult Remove(int? task_id)
        {
            var remove_variant = _context.Tasks.FirstOrDefault(H => H.task_id == task_id);

            if (remove_variant != null){
                _context.Tasks.Remove(remove_variant);
                _context.SaveChanges();
                TempData["message"] = $"Вариант {remove_variant.task_name} удален";
            }

            return RedirectToAction(nameof(Index));
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