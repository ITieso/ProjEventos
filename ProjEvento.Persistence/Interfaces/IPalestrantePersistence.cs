using ProjEvento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEvento.Persistence.Interfaces
{
   public interface IPalestrantePersistence
    {

        //PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesByNameAsync(string tema, bool incluirEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos);

        Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteid, bool incluirEventos);
    }
}
