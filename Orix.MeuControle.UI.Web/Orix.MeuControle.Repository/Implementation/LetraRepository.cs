using System;
using System.Collections.Generic;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.DataAccess;
using System.Linq;

namespace Orix.MeuControle.Repository.Implementation
{
    public class LetraRepository : Contracts.ILetraRepository
    {
        Conexao _conexao = new Conexao();

        public LetraDomainModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(LetraDomainModel dadosTela)
        {
            _conexao.Letra.Add(dadosTela);
            _conexao.SaveChanges();
        }

        public void Editar(LetraDomainModel dadosTela)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<LetraDomainModel> Listar()
        {
            return _conexao.Letra.OrderBy(x => x.Letra).ToList();
        }
    }
}
