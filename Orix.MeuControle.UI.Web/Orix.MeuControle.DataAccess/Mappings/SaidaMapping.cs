using Orix.MeuControle.Domain.Mapa;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public class SaidaMapping : EntityTypeConfiguration<SaidaDomainModel>
    {
        public SaidaMapping()
        {
            ToTable("TB_SAIDA");

            HasKey(x => x.ID);

            Property(x => x.Local).HasMaxLength(100).IsRequired().HasColumnName("NM_LOCAL");
            Property(x => x.Logradouro).HasMaxLength(250).HasColumnName("DS_LOGRADOURO");
        }
    }
}
