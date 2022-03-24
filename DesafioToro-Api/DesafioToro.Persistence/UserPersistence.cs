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
    public class UserPersistence : IUserPersistence
    {
        private readonly DatabaseContext _context;

        public UserPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByAccount(string account)
        {
            IQueryable<User> query = _context.tblUser;
            query = query.AsNoTracking().OrderBy(u => u.Account).Where(u => u.Account == account);
            return query.LastOrDefault();
        }
    }
}
