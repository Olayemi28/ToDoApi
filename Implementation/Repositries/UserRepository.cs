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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UniqueContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByEmail(string email)
        {
            return await _context.Users.AnyAsync(d => d.Email.Equals(email) && d.IsDeleted == false);
        }

        public async Task<bool> ExistsById(int id)
        {
            return await _context.Users.AnyAsync(s => s.Id == id && s.IsDeleted == false);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(b => b.Email.Equals(email) && b.IsDeleted == false);
        }
    }
}
