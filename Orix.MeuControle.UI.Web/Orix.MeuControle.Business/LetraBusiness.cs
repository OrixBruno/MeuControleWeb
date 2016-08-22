using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Business
{
    public class LetraBusiness : Base.IBusiness<LetraDomainModel>
    {
        LetraRepository _repository = new LetraRepository();

        public void Cadastrar(LetraDomainModel dadosTela)
        {
            _repository.Cadastrar(dadosTela);
        }
        public List<LetraDomainModel> Listar()
        {
            return _repository.Listar();
        }
        public void Editar(LetraDomainModel dadosTela)
        {
            _repository.Editar(dadosTela);
        }

        public void Excluir(int id)
        {
            _repository.Excluir(id);
        }

        public LetraDomainModel Buscar(int id)
        {
            return _repository.Buscar(id);
        }
    }
}
