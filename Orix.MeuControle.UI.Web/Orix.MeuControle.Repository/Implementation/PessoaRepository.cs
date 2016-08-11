using Orix.MeuControle.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orix.MeuControle.Domain.Surdos;
using Orix.MeuControle.DataAccess;
using System.Data.Entity;

namespace Orix.MeuControle.Repository.Implementation
{
    public class PessoaRepository : IPessoaRepository
    {
        Conexao _conexao = new Conexao();

        public PessoaDomainModel Buscar(int id)
        {
            return _conexao.Pessoa.Find(id);
        }

        public void Cadastrar(PessoaDomainModel pessoaTela)
        {
            _conexao.Pessoa.Add(pessoaTela);
            _conexao.SaveChanges();
        }

        public void Editar(PessoaDomainModel pessoaTela)
        {
            _conexao.Entry(pessoaTela).State = EntityState.Modified;
            _conexao.SaveChanges();
        }

        public void Excluir(int id)
        {
            _conexao.Pessoa.Remove(_conexao.Pessoa.Find(id));
            _conexao.SaveChanges();
        }

        public List<PessoaDomainModel> Listar()
        {
            return _conexao.Pessoa.OrderBy(x => x.Nome).ToList();
        }
    }
}
