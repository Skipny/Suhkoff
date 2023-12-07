using Microsoft.AspNetCore.Mvc;
using Suhkoff.Data;
using Suhkoff.Models;
using System.Diagnostics;

namespace Suhkoff.Controllers
{
    public class DetalisController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ApplicationContext _context;

        public DetalisController(ILogger<TaskController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }

        public IActionResult Index(int? task_id)
        {
            var viewModel = new HomeViewModel();
            viewModel.Users = _context.Users.ToList();
            viewModel.task = _context.Tasks.FirstOrDefault(x => x.task_id == task_id);
            return View(viewModel);
            
            
            
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