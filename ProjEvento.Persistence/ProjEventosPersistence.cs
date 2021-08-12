using Microsoft.EntityFrameworkCore;
using ProjEvento.Domain.Models;

using ProjEvento.Persistence.Contexto;
using ProjEvento.Persistence.Interfaces;
using System.Linq;

using System.Threading.Tasks;

namespace ProjEvento.Persistence
{
   public class ProjEventosPersistence : IEventoPersistence
    {
        private readonly ProjEventoContext _context;
        public ProjEventosPersistence(ProjEventoContext context)
        {
            _context = context;
        }
      

        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
                                                       .Include(e => e.RedesSociais);
            if (incluirPalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(ep => ep.Palestrante);
            }
            query = query.AsNoTracking(). OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
                                                       .Include(e => e.RedesSociais);
            if (incluirPalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(ep => ep.Palestrante);
            }
            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventoByIdAsync(int eventoid, bool incluirPalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);
            if (incluirPalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(ep => ep.Palestrante);
            }
            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Id == eventoid);

            return await query.FirstOrDefaultAsync();
        }


       
    }
}
