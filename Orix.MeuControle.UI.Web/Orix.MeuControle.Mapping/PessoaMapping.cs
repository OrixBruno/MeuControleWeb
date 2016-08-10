using Orix.MeuControle.Domain.Surdos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Mapping
{
    public class PessoaMapping : EntityTypeConfiguration<PessoaDomainModel>
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
