using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Entities;

namespace UniqueTodoApplication.Interface.IRespositries
{
   public interface ITodoitemRepository : IRepository<Todoitem>
   {
        Task<bool> ExistsByNameAndTime(string name, DateTime time);

        Task<bool> ExistsById(int id);

        Task<Todoitem> GetByName(string name);
   }
}
