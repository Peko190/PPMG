using Microsoft.EntityFrameworkCore;
using TaskPlannerMiniData;
using TaskPlannerMiniData.Entities;
using TaskPlannerMiniData.Enums;
using TaskPlannerMiniServices.Contracts;

namespace TaskPlannerMiniServices
{
    public class TaskService : ITaskService
    {
        private readonly TaskPlannerDbContext _db;

        public TaskService(TaskPlannerDbContext context)
        {
            _db = context;
        }

        public Task<List<TaskItem>> GetAll()
        {
            return _db.Tasks
                .Include(t => t.Category)
                .Include(t => t.User)
                .OrderBy(t => t.DueDate)
                .ToListAsync();
        }

        public Task<List<Category>> GetCategories()
        {
            return _db.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return _db.Users
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public async Task Create(
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

            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
        }
    }
}