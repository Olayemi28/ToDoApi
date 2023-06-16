using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueTodoApplication.Models
{
    public class SubcategoryRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class UpdateSubcategoryRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
