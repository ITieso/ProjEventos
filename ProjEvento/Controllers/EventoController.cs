using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjEvento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjEvento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento()
              {
                Id = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "São Paulo",
                Lote = "1º Lote",
                QtdPessoas = 250,
                Data = DateTime.Now.AddDays(2).ToString(),
                ImagemUrl = "foto.png"
            },

            new Evento()
              {
                Id = 2,
                Tema = "Angular + Novidades",
                Local = "São Paulo",
                Lote = "2º Lote",
                QtdPessoas = 300,
                Data = DateTime.Now.AddDays(3).ToString(),
                ImagemUrl = "foto2.png"
            }
        };
        public EventoController()
        {
         
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;


        }


        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(x => x.Id == id);


        }
          
        

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }


        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }

}
