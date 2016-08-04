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
        public void Cadastrar(PessoaDomainModel surdoTela)
        {
            if (surdoTela.Idade < 5)
                throw new Exception("Idade minima de 5 anos");
            
        }
        public List<PessoaDomainModel> Lista()
        {
            return new List<PessoaDomainModel>();
        }
        public void Editar(PessoaDomainModel surdoTela)
        {
            if (surdoTela.Idade < 5)
                throw new Exception("Idade minima de 5 anos");
        }
    }
}
