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
    public class TodoitemRepository : BaseRepository<Todoitem>, ITodoitemRepository
    {
        public TodoitemRepository(UniqueContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsById(int id)
        {
            return await _context.Todoitems.AnyAsync(t => t.Id == id && t.IsDeleted == false);
        }

        public async Task<bool> ExistsByNameAndTime(string name, DateTime time)
        {
            return await _context.Todoitems.AnyAsync(d => d.Name.Equals(name) && d.OriginalTime == time && d.IsDeleted == false);
        }

        public async Task<Todoitem> GetByName(string name)
        {
            return await _context.Todoitems.FirstOrDefaultAsync(n => n.Name.Equals(name) && n.IsDeleted == false);
        }
    }
}
