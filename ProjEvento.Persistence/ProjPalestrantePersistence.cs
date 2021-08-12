using Microsoft.EntityFrameworkCore;
using ProjEvento.Domain.Models;
using ProjEvento.Persistence.Contexto;
using ProjEvento.Persistence.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProjEvento.Persistence
{
   public class ProjPalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProjEventoContext _context;
        public ProjPalestrantePersistence(ProjEventoContext context)
        {
            _context = context;
        }
 

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.
               Include(p => p.RedesSociais);
            if (incluirEventos)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);
            }
            query.AsNoTracking().OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteid, bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);
            if (incluirEventos)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);
            }
            query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == palestranteid);
            return await query.FirstOrDefaultAsync();
                

        }


        public async Task<Palestrante[]> GetAllPalestrantesByNameAsync(string nome, bool incluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
               .Include(p => p.RedesSociais);
            if (incluirEventos)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Evento);
            }
            query.AsNoTracking().OrderBy(p => p.Id)
                 .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }


       
    }
}
