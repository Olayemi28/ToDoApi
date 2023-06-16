using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Enum;

namespace UniqueTodoApplication.Models
{
    public class TodoitemRequestModel
    {
        public string Name { get; set; }

        public Status Status { get; set; }

        public string Description { get; set; }
        

        public Priority Priority { get; set; }

        public string TimeInterval { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime OriginalTime { get; set; }
    }

    public class UpdateTodoitemRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public TimeSpan TimeInterval { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime OriginalTime { get; set; }
    }
}
