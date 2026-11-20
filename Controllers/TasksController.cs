using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskPlannerMiniData;
using TaskPlannerMiniData.Entities;
using TaskPlannerMiniData.Enums;

namespace TaskPlannerMini.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskPlannerDbContext _context;

        public TasksController(TaskPlannerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!_context.Tasks.Any())
            {
                var category = new Category
                {
                    Name = "Училище",
                    Description = "Задачи за учене"
                };

                var user = new User
                {
                    Name = "Тестов потребител",
                    Email = "test@example.com"
                };

                _context.Tasks.Add(new TaskItem
                {
                    Title = "Подготовка за изпит",
                    Description = "Преговор на материала по програмиране",
                    DueDate = DateTime.Today.AddDays(3),
                    Priority = TaskPriority.High,
                    Status = TaskStatuss.Pending,
                    Category = category,
                    User = user
                });

                _context.SaveChanges();
            }

            var tasks = _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.User)
                .ToList();

            return View(tasks);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(
            string title,
            string? description,
            DateTime dueDate,
            TaskPriority priority,
            TaskStatuss status,
            int categoryId,
            int userId)
        {
            var task = new TaskItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = priority,
                Status = status,
                CategoryId = categoryId,
                UserId = userId
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}