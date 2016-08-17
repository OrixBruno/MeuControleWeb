using System;
using System.Collections.Generic;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.DataAccess;
using System.Linq;
using System.Data.Entity;

namespace Orix.MeuControle.Repository.Implementation
{
    public class LetraRepository : Contracts.ILetraRepository
    {
        Conexao _conexao = new Conexao();

        public LetraDomainModel Buscar(Int32 id)
        {
            return _conexao.Letra.Find(id);
        }

        public void Cadastrar(LetraDomainModel dadosTela)
        {
            _conexao.Letra.Add(dadosTela);
            _conexao.SaveChanges();
        }

        public void Editar(LetraDomainModel dadosTela)
        {
            _conexao.Entry(dadosTela).State = EntityState.Modified;
            _conexao.SaveChanges();
        }

        public void Excluir(Int32 id)
        {
            _conexao.Letra.Remove(_conexao.Letra.Find(id));
            _conexao.SaveChanges();
        }

        public List<LetraDomainModel> Listar()
        {
            return _conexao.Letra.OrderBy(x => x.Letra).ToList();
        }
    }
}
