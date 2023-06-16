using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueTodoApplication.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<ItemSubcategory> ItemSubcategories { get; set; } = new List<ItemSubcategory>();
    }
}
