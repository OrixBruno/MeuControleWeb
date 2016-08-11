using Orix.MeuControle.Domain.Surdos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Repository.Contracts
{
    interface IPessoaRepository
    {
        void Cadastrar(PessoaDomainModel pessoaTela);

        void Editar(PessoaDomainModel pessoaTela);

        void Excluir(Int32 id);

        PessoaDomainModel Buscar(Int32 id);

        List<PessoaDomainModel> Listar();
    }
}
