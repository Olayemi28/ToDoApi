using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Entities;

namespace UniqueTodoApplication.Interface.IRespositries
{
   public interface IUserRepository : IRepository<User>
   {
        Task<bool> ExistsByEmail(string email);

        Task<bool> ExistsById(int id);

        Task<User> GetByEmail(string email);
    }
}
