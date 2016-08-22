using System;
using System.Collections.Generic;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.DataAccess;
using System.Linq;
using System.Data.Entity;
using Orix.MeuControle.Repository.Implementation.Base;

namespace Orix.MeuControle.Repository.Implementation
{
    public class LetraRepository : BaseRepository<LetraDomainModel>, Contracts.ILetraRepository
    {
        public List<LetraDomainModel> Listar()
        {
            return base.Listar().OrderBy(x => x.Letra).ToList();
        }
    }
}
