using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Business
{
    public class TerritorioBusiness : Base.IBusiness<TerritorioDomainModel>
    {
        TerritorioRepository _repository = new TerritorioRepository();

        public TerritorioDomainModel Buscar(int id)
        {
            return _repository.Buscar(id);
        }

        public void Cadastrar(TerritorioDomainModel dadosTela)
        {
            _repository.Cadastrar(dadosTela);
        }

        public void Editar(TerritorioDomainModel dadosTela)
        {
            _repository.Editar(dadosTela);
        }

        public void Excluir(int id)
        {
            _repository.Excluir(id);
        }

        public List<TerritorioDomainModel> Listar()
        {
            return _repository.Listar();
        }
    }
}
