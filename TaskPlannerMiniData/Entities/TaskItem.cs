using TaskPlannerMiniData.Enums;

namespace TaskPlannerMiniData.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public TaskPriority Priority { get; set; }

        public TaskStatuss Status { get; set; }

     
        public int CategoryId { get; set; }

        public int UserId { get; set; }

       
        public Category Category { get; set; } = null!;

        public User User { get; set; } = null!;

        public ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();
    }
}