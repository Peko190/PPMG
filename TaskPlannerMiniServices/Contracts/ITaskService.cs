using TaskPlannerMiniData.Entities;
using TaskPlannerMiniData.Enums;

namespace TaskPlannerMiniServices.Contracts
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAll();

        Task<List<Category>> GetCategories();

        Task<List<User>> GetUsers();

        Task Create(
            string title,
            string? description,
            DateTime dueDate,
            TaskPriority priority,
            TaskStatuss status,
            int categoryId,
            int userId);
    }
}