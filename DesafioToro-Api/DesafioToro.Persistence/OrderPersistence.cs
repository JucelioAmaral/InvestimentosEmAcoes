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
    public class OrderPersistence : IOrderPersistence
    {
        private readonly DatabaseContext _context;

        public OrderPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Order[]> GetTopFiveOrdersInSevensDays()
        {
            IQueryable<Order> query = _context.tblOrder;
            //5 ações mais negociadas nos últimos 7 dias.
            query = query.AsNoTracking().OrderByDescending(o => o.Amount)
                                        .Where(o => o.DateOrder >= DateTime.Now.AddDays(-7) && o.DateOrder <= DateTime.Now) 
                                        .Take(5);
            return query.ToArray();
        }
    }
}

