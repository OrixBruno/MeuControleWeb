using Orix.MeuControle.Domain.Mapa;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public sealed class LetraMapping : EntityTypeConfiguration<LetraDomainModel>
    {
        public LetraMapping()
        {
            ToTable("TB_LETRA");

            HasKey(x => x.ID);

            Property(x => x.Letra).IsFixedLength().IsRequired().HasColumnName("NM_LETRA");
            Property(x => x.Descricao).HasMaxLength(300).HasColumnName("DS_LETRA");
        }        
    }
}
