using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueTodoApplication.Models
{
    public class ItemRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<int> Subcategorys { get; set; } = new List<int>();
    }

    public class UpdateItemRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
