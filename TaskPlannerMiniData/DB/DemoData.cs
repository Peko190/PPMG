using TaskPlannerMiniData.Entities;
using TaskPlannerMiniData.Enums;

namespace TaskPlannerMiniData
{
    public static class DemoData
    {
        public static void Seed(TaskPlannerDbContext db)
        {
            if (db.Tasks.Any())
            {
                return;
            }

            var category = db.Categories.FirstOrDefault(c => c.Name == "Училище");

            if (category is null)
            {
                category = new Category
                {
                    Name = "Училище",
                    Description = "Задачи за учене"
                };
                db.Categories.Add(category);
            }

            var user = db.Users.FirstOrDefault(u => u.Email == "test@example.com");

            if (user is null)
            {
                user = new User
                {
                    Name = "Тестов потребител",
                    Email = "test@example.com"
                };
                db.Users.Add(user);
            }

            db.Tasks.Add(new TaskItem
            {
                Title = "Подготовка за изпит",
                Description = "Преговор на материала по програмиране",
                DueDate = DateTime.Today.AddDays(3),
                Priority = TaskPriority.High,
                Status = TaskStatuss.Pending,
                Category = category,
                User = user
            });

            db.SaveChanges();
        }
    }
}