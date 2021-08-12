using ProjEvento.Domain.Models;
using System.Threading.Tasks;

namespace ProjEvento.Persistence.Interfaces
{
    public interface IEventoPersistence
    {
        //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync( bool incluirPalestrantes = false);

        Task<Evento> GetAllEventoByIdAsync(int eventoid, bool incluirPalestrantes = false);

    }
}
