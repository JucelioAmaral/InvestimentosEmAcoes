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
    public class TargetPersistence: ITargetPersistence
    {
        private readonly DatabaseContext _context;

        public TargetPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Target> GetAccount(string account)
        {
            IQueryable<Target> query = _context.tblTarget;
            query = query.AsNoTracking().OrderBy(t => t.TargetId).Where(t => t.Account == account);
            return query.LastOrDefault();
        }

        public async Task<Target> GetTargetIdByAccount(string account)
        {
            IQueryable<Target> query = _context.tblTarget;
            query = query.AsNoTracking().OrderBy(t => t.TargetId).Where(t => t.Account == account);
            return query.LastOrDefault();
        }        
    }
}
