using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBot_Part2.Models
{
    public class TaskItem
    {
        public int TaskID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ReminderDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
