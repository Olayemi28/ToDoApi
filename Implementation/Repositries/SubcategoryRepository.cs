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
    public class SubcategoryRepository : BaseRepository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(UniqueContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsById(int id)
        {
            return await _context.Subcategories.AnyAsync(d => d.Id == id && d.IsDeleted == false);
        }

        public async Task<bool> ExistsByName(string name)
        {
            return await _context.Subcategories.AnyAsync(s => s.Name.Equals(name) && s.IsDeleted == false);
        }

        public Task<IEnumerable<Subcategory>> GetAllSubcategoryByCategoryName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Subcategory> GetByName(string name)
        {
            return await _context.Subcategories.FirstOrDefaultAsync(b => b.Name.Equals(name) && b.IsDeleted == false);
        }

        public IEnumerable<Subcategory> GetSelected(IList<int> ids)
        {
            return _context.Subcategories.Where(d => ids.Contains(d.Id)).ToList();
        }
    }
}
