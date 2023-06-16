using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniqueTodoApplication.Context;
using UniqueTodoApplication.Entities;
using UniqueTodoApplication.Interface.IRespositries;

namespace UniqueTodoApplication.Implementation.Repositries
{
    public class ReminderRepository : BaseRepository<Reminder>, IReminderRepository
    {
        public ReminderRepository(UniqueContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reminder>> GetPendingReminder()
        {
           var reminders = await _context.Reminders.Where(r => r.Time >= DateTime.Now).OrderBy(d => d.Time).ToListAsync();
           return reminders;
        }
    }
}
