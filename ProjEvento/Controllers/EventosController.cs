using Microsoft.AspNetCore.Mvc;
using ProjEvento.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using ProjEvento.Persistence.Contexto;
using ProjEvento.Application.Services;
using System.Threading.Tasks;

namespace ProjEvento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos == null) return NotFound("Nenhum Evento Encontrado");
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(500, ex);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetAllEventoByIdAsync(id, true);
                if (evento == null) return NotFound("Nenhum Evento Encontrado com esse ID");
                return Ok(evento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(500, ex);
            }
        }


        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento == null) return NotFound("Nenhum Evento Encontrado com esse tema");
                return Ok(evento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(500, ex);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEvento(model);
                if (evento == null) return BadRequest();
                return Ok(evento);
                
            }
            catch (Exception ex)
            {

                return this.StatusCode(500, $"Erro ao adcionar novo evento: {ex.Message}");
            }
           
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);
                if (evento == null) return NotFound($"Nenhum evento encontrado com o id: {id}");
                return Ok(evento);
            }
            catch (Exception ex)
            {

                return this.StatusCode(500, $"Não foi possivel atualizar este evento:{ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _eventoService.DeleteEvento(id))
                return Ok("Deletado");

                return BadRequest("Erro ao deletar evento");
            }
            catch (Exception ex)
            {

                return this.StatusCode(500, $"Não foi possivel deletar esse evento {ex.Message}");
            }

        }
    }

}
