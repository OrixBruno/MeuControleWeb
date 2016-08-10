using Orix.MeuControle.DataAccess;
using Orix.MeuControle.Domain.Surdos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Business
{
    public class SurdoBusiness
    {
        Conexao conexao = new Conexao();

        public void Cadastrar(PessoaDomainModel surdoTela)
        {
            if (surdoTela.Idade < 5)
                throw new Exception("Idade minima de 5 anos");
            conexao.Pessoa.Add(surdoTela);
        }
        public List<PessoaDomainModel> Lista()
        {
            return conexao.Pessoa.ToList();
        }
        public void Editar(PessoaDomainModel surdoTela)
        {
            if (surdoTela.Idade < 5)
                throw new Exception("Idade minima de 5 anos");
        }
    }
}
