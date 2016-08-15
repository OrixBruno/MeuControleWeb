using System;
using System.Collections.Generic;

namespace Orix.MeuControle.Domain.Mapa
{
    public class TerritorioDomainModel
    {
        public Int32 ID { get; set; }

        public String Nome { get; set; }

        public virtual ICollection<MapaDomainModel> ListaMapa { get; set; }
    }
}
