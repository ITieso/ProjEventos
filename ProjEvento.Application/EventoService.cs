using ProjEvento.Application.Services;
using ProjEvento.Persistence.Interfaces;
using ProjEvento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEvento.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventoPersistence _eventoPersistence;

        public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventoPersistence)
        {
            _geralPersistence = geralPersistence;
            _eventoPersistence = eventoPersistence;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                     return await _eventoPersistence.GetAllEventoByIdAsync(model.Id, false); // caso eu queira fazer algo com esse cara, ai eu ja retorno o id dele
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;
                _geralPersistence.Update(model);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetAllEventoByIdAsync(model.Id, false); // caso eu queira fazer algo com esse cara, ai eu ja retorno o id dele
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId);
                if (evento == null) throw new Exception("Evento para deletar não foi encontrado");

                _geralPersistence.Delete(evento);

                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(incluirPalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, incluirPalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventoByIdAsync(int eventoid, bool incluirPalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventoByIdAsync(eventoid, incluirPalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



    }
}
