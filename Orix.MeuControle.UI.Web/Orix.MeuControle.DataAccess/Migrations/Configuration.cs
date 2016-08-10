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
            context.Pessoa.Add(new PessoaDomainModel() {
                Bairro = "Cidade Kemel",
                Codigo = 0,
                Genero = "Homem",
                Idade = 19,
                Nome = "Bruno Silva do Nascimento",
                Numero = 154,
                Observacao = "Sabe libras",
                Rua = "Thyrso Burgos Lopes"
            });
        }
    }
}
