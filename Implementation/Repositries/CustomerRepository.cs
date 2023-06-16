using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Context;
using UniqueTodoApplication.Entities;
using UniqueTodoApplication.Interface.IRespositries;

namespace UniqueTodoApplication.Implementation.Repositries
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository    
    {
        public CustomerRepository(UniqueContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            return await _context.Customers.AnyAsync(t => t.Email.Equals(email) && t.IsDeleted == false);
        }

        public async Task<bool> ExistsById(int id)
        {
            return await _context.Customers.AnyAsync(n => n.Id == id && n.IsDeleted == false);
        }
        public async Task<Customer> GetByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(m => m.Email.Equals(email) && m.IsDeleted == false);
        }
    }
}
