using DesafioToro.Domain;
using DesafioToro.Persistence.Context;
using DesafioToro.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioToro.Persistence
{
    public class OriginPersistence : IOriginPersistence
    {
        private readonly DatabaseContext _context;

        public OriginPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Origin> GetCPFOrigin(string cpf)
        {
            IQueryable<Origin> query = _context.tblOrigin;
            query = query.AsNoTracking().OrderBy(c => c.OriginId).Where(c => c.CPF == cpf);
            return query.FirstOrDefault();
        }
    }
}
