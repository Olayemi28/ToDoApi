using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Entities;

namespace UniqueTodoApplication.Interface.IRespositries
{
   public interface IReminderRepository : IRepository<Reminder>
   {
      public Task<IEnumerable<Reminder>> GetPendingReminder();
   }
}
