using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Business
{
    public class SaidaBusiness : Base.IBusiness<SaidaDomainModel>
    {
        SaidaRepository _repository = new SaidaRepository();

        public SaidaDomainModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(SaidaDomainModel dadosTela)
        {
            _repository.Cadastrar(dadosTela);
        }

        public void Editar(SaidaDomainModel dadosTela)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<SaidaDomainModel> Listar()
        {
            return _repository.Listar();
        }
    }
}
