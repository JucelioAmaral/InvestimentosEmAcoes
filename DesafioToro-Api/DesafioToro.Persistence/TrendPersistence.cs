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
    public class TrendPersistence : ITrendPersistence
    {
        private readonly DatabaseContext _context;

        public TrendPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Trend[]> GetTrends()
        {
            IQueryable<Trend> query = _context.tblTrend;
            query = query.AsNoTracking().OrderBy(t => t.TrendId);
            return query.ToArray();
        }

        public async Task<Trend> GetTrendByName(string orderName)
        {
            IQueryable<Trend> query = _context.tblTrend;
            query = query.AsNoTracking().OrderBy(t => t.TrendId).Where(t => t.Symbol == orderName);
            return query.FirstOrDefault();
        }
    }
}
