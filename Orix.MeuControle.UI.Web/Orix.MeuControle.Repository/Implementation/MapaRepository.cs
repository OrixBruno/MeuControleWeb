using System;
using System.Collections.Generic;
using System.Linq;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.DataAccess;
using System.Data.Entity;

namespace Orix.MeuControle.Repository.Implementation
{
    public class MapaRepository : Contracts.IMapaRepository
    {
        Conexao _conexao = new Conexao();

        public MapaDomainModel Buscar(Int32 id)
        {
            return _conexao.Mapa.Find(id);
        }

        public void Cadastrar(MapaDomainModel dadosTela)
        {
            _conexao.Mapa.Add(dadosTela);
            _conexao.SaveChanges();
        }

        public void Editar(MapaDomainModel dadosTela)
        {
            _conexao.Entry(dadosTela).State = EntityState.Modified;
            _conexao.SaveChanges();
        }

        public void Excluir(Int32 id)
        {
            _conexao.Mapa.Remove(_conexao.Mapa.Find(id));
            _conexao.SaveChanges();
        }

        public List<MapaDomainModel> Listar()
        {
            return _conexao.Mapa.ToList();
        }
    }
}
