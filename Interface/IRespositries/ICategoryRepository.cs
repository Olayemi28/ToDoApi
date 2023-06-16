using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Entities;

namespace UniqueTodoApplication.Interface.IRespositries
{
   public interface ICategoryRepository : IRepository<Category>
   {
        Task<bool> ExistsByName(string name);

        Task<bool> ExistsById(int id);

        Task<Category> GetByName(string name);
    }
}
