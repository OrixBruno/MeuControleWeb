using Orix.MeuControle.DataAccess.Mappings;
using Orix.MeuControle.Domain.Surdos;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Orix.MeuControle.DataAccess
{
    public class Conexao : DbContext
    {
        public Conexao()
            : base(@"Data Source=(localdb)\v11.0;Initial Catalog=DBCONTROLEMAPAS;Integrated Security=True")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<Conexao>(new CreateDatabaseIfNotExists<Conexao>());

            //Database.SetInitializer<Conexao>(new MigrateDatabaseToLatestVersion<Conexao, Configuration>());
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
