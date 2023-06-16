using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueTodoApplication.Models
{
    public class CategoryRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class UpdateCategoryRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
