using Orix.MeuControle.Domain.Mapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Repository.Contracts
{
    interface ITerritorioRepository : Base.IGravacao<TerritorioDomainModel>, Base.ILeitura<TerritorioDomainModel>
    {
    }
}
