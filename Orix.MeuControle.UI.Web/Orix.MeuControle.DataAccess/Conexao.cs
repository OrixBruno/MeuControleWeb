using Orix.MeuControle.Domain.Surdos;
using Orix.MeuControle.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.DataAccess
{
    public class Conexao : DbContext
    {
        public Conexao()
            : base("DataContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<Conexao>(new CreateDatabaseIfNotExists<Conexao>());

            //Caso exista o contexto habilite está opção
            //Database.SetInitializer<UserDbContext>(new MigrateDatabaseToLatestVersion<UserDbContext, Configuration>());
        }

        public DbSet<PessoaDomainModel> Pessoa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<String>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new PessoaMapping());
        }
    }
}
