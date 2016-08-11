using Orix.MeuControle.Domain.Surdos;
using System.Data.Entity.ModelConfiguration;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public sealed class PessoaMapping : EntityTypeConfiguration<PessoaDomainModel>
    {
        public PessoaMapping()
        {
            ToTable("Pessoa");

            HasKey(x => x.Codigo);

            Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("NM_PESSOA");
            Property(x => x.Bairro).HasMaxLength(100).IsRequired().HasColumnName("DS_BAIRRO");
            Property(x => x.Genero).HasMaxLength(100).IsRequired().HasColumnName("DS_GENERO");
            Property(x => x.Idade).IsRequired().HasColumnName("DS_IDADE");
            Property(x => x.Numero).IsRequired().HasColumnName("DS_NUMERO");
            Property(x => x.Observacao).HasMaxLength(250).IsRequired().HasColumnName("DS_OBSERVACAO");
            Property(x => x.Rua).HasMaxLength(100).IsRequired().HasColumnName("DS_RUA");
        }
    }
}
