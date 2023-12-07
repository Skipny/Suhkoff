using Microsoft.AspNetCore.Mvc;
using Suhkoff.Data;
using Suhkoff.Models;
using System.Diagnostics;

namespace Suhkoff.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ApplicationContext _context;

        public TaskController(ILogger<TaskController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }

        public IActionResult Index(TaskViewModel input, int? task_id)
        {
            var viewModel = new HomeViewModel();
            viewModel.Users = _context.Users.ToList();

            if (task_id != null){
                viewModel.task = _context.Tasks.FirstOrDefault(x => x.task_id == task_id);
                return View(viewModel);
            }
            else if (input?.id != 0){
                var existVariant = _context.Tasks.FirstOrDefault(x => x.task_id == input.id);
                if (existVariant != null){
                    existVariant.task_name = input.task_name;
                    existVariant.task_description = input.task_description;
                    existVariant.task_status = input.task_status;
                    _context.Tasks.Update(existVariant);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else{
                viewModel.Tasks = _context.Tasks.ToList();
                if (ModelState.IsValid){
                    var task = new tasks{
                        task_name = input.task_name,
                        task_description = input.task_description,
                        task_status = input.task_status,
                        users = _context.Users.FirstOrDefault(x => x.user_id == input.user_id),
                        dateTime = DateTime.Now
                    };
                    _context.Tasks.Add(task);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View(viewModel);
            }
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