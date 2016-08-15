using System;
using System.Collections.Generic;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.DataAccess;
using System.Linq;

namespace Orix.MeuControle.Repository.Implementation
{
    public class SaidaRepository : Contracts.ISaidaRepository
    {
        Conexao _conexao = new Conexao();

        public SaidaDomainModel Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(SaidaDomainModel dadosTela)
        {
            _conexao.Saida.Add(dadosTela);
            _conexao.SaveChanges();
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
            return _conexao.Saida.OrderBy(x => x.Local).ToList();
        }
    }
}
