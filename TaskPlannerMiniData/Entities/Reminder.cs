using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlannerMiniData.Entities
{
    public class Reminder
    {
        public int Id { get; set; }

        public DateTime ReminderDate { get; set; }

        public bool IsSent { get; set; }

        public int TaskItemId { get; set; }

        public TaskItem TaskItem { get; set; } = null!;
    }
}
