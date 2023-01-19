using Demo_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private static List<Client> _clients = new List<Client>()
        {
            new Client(){ idClient = 1, nom = "Legrain", prenom ="Samuel", email="samuel.legrain@bstorm.be", pass= "********", adresse = null},
            new Client(){ idClient = 2, nom = "Willis", prenom ="Bruce", email="bruce.willis@bstorm.be", pass= "********", adresse = "Avenue des cerisiers 16\n1200 Bruxelles"},
            new Client(){ idClient = 3, nom = "Norris", prenom ="Chuck", email="chuck.norris@bstorm.be", pass= "********", adresse = "Boulevard des innocents 42\n5000 Namur"},
            new Client(){ idClient = 4, nom = "Cordy", prenom ="Annie", email="annie.cordy@bstorm.be", pass= "********", adresse = "Tunnel Léopold II\n1000 Bruxelles"}
        };

        private static int _nextId = 5;

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _clients.ToArray();
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return _clients.Find(c => c.idClient == id);
        }

        [HttpPost]
        public int Post(Client entity)
        {
            entity.idClient = _nextId;
            _clients.Add(entity);
            _nextId++;
            return entity.idClient;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Client client = Get(id);
            if (client is null) return false;
            _clients.Remove(client);
            return true;
        }

        [HttpPut("{id}")]
        public bool Put(int id, Client entity)
        {
            Client client = Get(id);
            if (client is null) return false;
            client.nom = entity.nom;
            client.prenom = entity.prenom;
            client.adresse = entity.adresse;
            client.email = entity.email;
            return true;
        }
    }
}
