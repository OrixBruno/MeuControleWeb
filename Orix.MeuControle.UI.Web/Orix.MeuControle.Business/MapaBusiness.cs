using System;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation;
using System.Collections.Generic;

namespace Orix.MeuControle.Business
{
    public class MapaBusiness : Base.IBusiness<MapaDomainModel>
    {
        MapaRepository _repository = new MapaRepository();

        public void Adicionar(MapaDomainModel mapaDomainModel)
        {
            _repository.Cadastrar(mapaDomainModel);
        }

        public MapaDomainModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(MapaDomainModel dadosTela)
        {
            throw new NotImplementedException();
        }

        public void Editar(MapaDomainModel dadosTela)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Int32 id)
        {
            _repository.Excluir(id);
        }

        public List<MapaDomainModel> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
