
using ProjEvento.Persistence.Contexto;
using ProjEvento.Persistence.Interfaces;

using System.Threading.Tasks;

namespace ProjEvento.Persistence
{
 public class ProjGeralPersistence : IGeralPersistence
    {
        private readonly ProjEventoContext _context;
        public ProjGeralPersistence(ProjEventoContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
            //_context.SaveChangesAsync();
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);

        }

        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;

        }
}
}
