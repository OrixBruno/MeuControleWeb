using System;
using System.Collections.Generic;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.DataAccess;
using System.Linq;
using System.Data.Entity;

namespace Orix.MeuControle.Repository.Implementation
{
    public class TerritorioRepository : Contracts.ITerritorioRepository
    {
        Conexao _conexao = new Conexao();
        public TerritorioDomainModel Buscar(Int32 id)
        {
            return _conexao.Territorio.Find(id);
        }

        public void Cadastrar(TerritorioDomainModel dadosTela)
        {
            _conexao.Territorio.Add(dadosTela);
            _conexao.SaveChanges();
        }

        public void Editar(TerritorioDomainModel dadosTela)
        {
            _conexao.Entry(dadosTela).State = EntityState.Modified;
            _conexao.SaveChanges();
        }

        public void Excluir(Int32 id)
        {
            _conexao.Territorio.Remove(_conexao.Territorio.Find(id));
            _conexao.SaveChanges();
        }

        public List<TerritorioDomainModel> Listar()
        {
            return _conexao.Territorio.OrderBy(x => x.Nome).ToList();
        }
    }
}
