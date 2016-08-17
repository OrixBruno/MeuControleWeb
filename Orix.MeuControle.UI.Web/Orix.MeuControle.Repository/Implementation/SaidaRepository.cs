using System;
using System.Collections.Generic;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.DataAccess;
using System.Linq;
using System.Data.Entity;

namespace Orix.MeuControle.Repository.Implementation
{
    public class SaidaRepository : Contracts.ISaidaRepository
    {
        Conexao _conexao = new Conexao();

        public SaidaDomainModel Buscar(Int32 id)
        {
            return _conexao.Saida.Find(id);
        }

        public void Cadastrar(SaidaDomainModel dadosTela)
        {
            _conexao.Saida.Add(dadosTela);
            _conexao.SaveChanges();
        }

        public void Editar(SaidaDomainModel dadosTela)
        {
            _conexao.Entry(dadosTela).State = EntityState.Modified;
            _conexao.SaveChanges();
        }

        public void Excluir(Int32 id)
        {
            _conexao.Saida.Remove(_conexao.Saida.Find(id));
        }

        public List<SaidaDomainModel> Listar()
        {
            return _conexao.Saida.OrderBy(x => x.Local).ToList();
        }
    }
}
