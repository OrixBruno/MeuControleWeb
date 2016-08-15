using System;
using System.Collections.Generic;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.DataAccess;
using System.Linq;

namespace Orix.MeuControle.Repository.Implementation
{
    public class TerritorioRepository : Contracts.ITerritorioRepository
    {
        Conexao _conexao = new Conexao();
        public TerritorioDomainModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TerritorioDomainModel dadosTela)
        {
            _conexao.Territorio.Add(dadosTela);
            _conexao.SaveChanges();
        }

        public void Editar(TerritorioDomainModel dadosTela)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<TerritorioDomainModel> Listar()
        {
            return _conexao.Territorio.OrderBy(x => x.Nome).ToList();
        }
    }
}
