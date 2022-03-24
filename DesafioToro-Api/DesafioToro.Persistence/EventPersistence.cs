using DesafioToro.Domain;
using DesafioToro.Persistence.Context;
using DesafioToro.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioToro.Persistence
{
    public class EventPersistence: IEventPersistence
    {
        private readonly DatabaseContext _context;

        public EventPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Event> GetEvent(int IdTarget)
        {
            IQueryable<Event> query = _context.tblEvent;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.TargetId == IdTarget);
            return query.LastOrDefault();
        }
    }
}
