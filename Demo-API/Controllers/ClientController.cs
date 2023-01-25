using Demo_API.Models;
using BLL = Demo_BLL.Entities;
using Demo_Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Demo_API.Handlers;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /*FAKE DB
         * private static List<Client> _clients = new List<Client>()
        {
            new Client(){ idClient = 1, nom = "Legrain", prenom ="Samuel", email="samuel.legrain@bstorm.be", pass= "********", adresse = null},
            new Client(){ idClient = 2, nom = "Willis", prenom ="Bruce", email="bruce.willis@bstorm.be", pass= "********", adresse = "Avenue des cerisiers 16\n1200 Bruxelles"},
            new Client(){ idClient = 3, nom = "Norris", prenom ="Chuck", email="chuck.norris@bstorm.be", pass= "********", adresse = "Boulevard des innocents 42\n5000 Namur"},
            new Client(){ idClient = 4, nom = "Cordy", prenom ="Annie", email="annie.cordy@bstorm.be", pass= "********", adresse = "Tunnel Léopold II\n1000 Bruxelles"}
        };

        private static int _nextId = 5;*/

        private readonly IClientRepository<BLL.Client, int> _service;

        public ClientController(IClientRepository<BLL.Client, int> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Client> result = _service.Get().Select(c => c.ToAPI());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Client result = _service.Get(id).ToAPI();
            if(result is null) return NotFound() ;
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Client entity)
        {
            entity.idClient = _service.Insert(entity.ToBLL());
            entity.pass = "********";
            return CreatedAtAction(nameof(Get),new { id = entity.idClient }, entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.Delete(id)) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Client entity)
        {
            if (!_service.Update(id, entity.ToBLL())) return NotFound();
            entity.pass = "********";
            return CreatedAtAction(nameof(Get), new { id = id }, entity);
        }
    }
}
