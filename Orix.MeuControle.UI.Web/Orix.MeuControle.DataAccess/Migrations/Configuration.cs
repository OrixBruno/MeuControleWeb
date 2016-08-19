namespace Orix.MeuControle.DataAccess.Migrations
{
    using Domain.Surdos;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Conexao>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Conexao context)
        {

        }
    }
}
