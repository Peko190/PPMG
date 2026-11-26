using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskPlannerMiniData.Enums;
using TaskPlannerMiniServices.Contracts;

namespace TaskPlannerMini.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAll();

            return View(tasks);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _taskService.GetCategories(), "Id", "Name");
            ViewBag.Users = new SelectList(await _taskService.GetUsers(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            string title,
            string? description,
            DateTime dueDate,
            TaskPriority priority,
            TaskStatuss status,
            int categoryId,
            int userId)
        {
            await _taskService.Create(title, description, dueDate, priority, status, categoryId, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}