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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(UniqueContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsById(int id)
        {
            return await _context.Roles.AnyAsync(d => d.Id == id);
        }

        public async Task<bool> ExistsByName(string name)
        {
            return await _context.Roles.AnyAsync(n => n.Name.Equals(name));
        }

        public async Task<Role> GetByName(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(b => b.Name.Equals(name) && b.IsDeleted == false);
        }
    }
}
