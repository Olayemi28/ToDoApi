using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueTodoApplication.Entities
{
    public class Reminder : BaseEntity
    {
        public int TodoitemId { get; set; }

        public Todoitem Todoitem { get; set; }

        public DateTime Time { get; set; }
    }
}
