using Microsoft.AspNetCore.Mvc;

namespace TaskPlannerMini.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
