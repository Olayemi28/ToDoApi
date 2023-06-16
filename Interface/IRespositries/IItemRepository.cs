using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Entities;

namespace UniqueTodoApplication.Interface.IRespositries
{
   public interface IItemRepository : IRepository<Item>
   {
        Task<bool> ExistsByName(string name);

        Task<bool> ExistsById(int id);

        Task<Item> GetByName(string name);

        public IList<Item> GetItemBySubcategory(int subcategoryId);
    }
}
