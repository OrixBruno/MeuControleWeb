using Orix.MeuControle.DataAccess;
using Orix.MeuControle.Repository.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Orix.MeuControle.Repository.Implementation.Base
{
    public class BaseRepository<TEntity> where TEntity : class,new()
    {
            protected DbSet<TEntity> _table;
            protected Conexao _conexao;
            public BaseRepository()
            {
                _conexao = new Conexao();
                _table = _conexao.Set<TEntity>();

            }
            private void SaveChanges()
            {
                _conexao.SaveChanges();
            }

            public TEntity Buscar(Int32 id)
            {
                return _table.Find(id);
            }

            public void Cadastrar(TEntity dadosTela)
            {
                _table.Add(dadosTela);
                SaveChanges();
            }
            public void Editar(TEntity dadosTela)
            {
                _conexao.Entry(dadosTela).State = EntityState.Modified;
                SaveChanges();
            }

            public void Excluir(Int32 id)
            {
                _table.Remove(_table.Find(id));
                SaveChanges();
            }

            public List<TEntity> Listar()
            {
                return _table.ToList();
            }
    }
}
