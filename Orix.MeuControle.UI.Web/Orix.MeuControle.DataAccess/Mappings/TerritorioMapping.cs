using Orix.MeuControle.Domain.Mapa;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public class TerritorioMapping : EntityTypeConfiguration<TerritorioDomainModel>
    {
        public TerritorioMapping()
        {
            ToTable("TB_TERRITORIO");

            HasKey(x => x.ID);

            Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("NM_TERRITORIO");
        }
    }
}
