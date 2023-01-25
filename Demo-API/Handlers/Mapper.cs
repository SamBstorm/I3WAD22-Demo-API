using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL = Demo_BLL.Entities;
using API = Demo_API.Models;

namespace Demo_API.Handlers
{
    public static class Mapper
    {
        public static BLL.Client ToBLL(this API.Client entity)
        {
            if (entity is null) return null;
            return new BLL.Client() {
                idClient = entity.idClient,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.adresse
                };
        }

        public static API.Client ToAPI(this BLL.Client entity)
        {
            if (entity is null) return null;
            return new API.Client()
            {
                idClient = entity.idClient,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.adresse
            };
        }
    }
}
