using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Entities;

namespace UniqueTodoApplication.Interface.IRespositries
{
   public interface ICustomerRepository : IRepository<Customer>
   {
        Task<bool> ExistsByEmail(string email);

        Task<bool> ExistsById(int id);

        Task<Customer> GetByEmail(string email);
   }
}
