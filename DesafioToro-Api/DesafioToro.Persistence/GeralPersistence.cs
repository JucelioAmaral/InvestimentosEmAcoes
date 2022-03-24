using DesafioToro.Persistence.Context;
using DesafioToro.Persistence.Contracts;
using System;
using System.Threading.Tasks;

namespace DesafioToro.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly DatabaseContext _context;

        public GeralPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
