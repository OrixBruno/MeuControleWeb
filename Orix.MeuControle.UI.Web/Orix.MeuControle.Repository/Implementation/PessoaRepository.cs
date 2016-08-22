using Orix.MeuControle.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using Orix.MeuControle.Domain.Surdos;
using Orix.MeuControle.Repository.Implementation.Base;

namespace Orix.MeuControle.Repository.Implementation
{
    public class PessoaRepository : BaseRepository<PessoaDomainModel>, IPessoaRepository
    {
        public new List<PessoaDomainModel> Listar()
        {
            return base.Listar().OrderBy(x => x.Nome).ToList();
        }
    }
}
