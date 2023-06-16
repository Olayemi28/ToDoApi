using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Entities;

namespace UniqueTodoApplication.Interface.IRespositries
{
   public interface ISubcategoryRepository : IRepository<Subcategory>
   {
        Task<bool> ExistsByName(string name);

        Task<bool> ExistsById(int id);

        Task<Subcategory> GetByName(string name);

        IEnumerable<Subcategory> GetSelected(IList<int> ids);
    }
}
