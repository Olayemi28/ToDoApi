using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Enum;

namespace UniqueTodoApplication.Models
{
    public class AchievementRequest
    {
        public DateTime Date { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public DateTime TimeInterval { get; set; }
    }
}
