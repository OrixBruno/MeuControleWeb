using System;
using System.Collections.Generic;

namespace Orix.MeuControle.Domain.Mapa
{
    public class LetraDomainModel
    {
        public Int32 ID { get; set; }
        public String Letra { get; set; }
        public String Descricao { get; set; }

        public virtual ICollection<MapaDomainModel> ListaMapa { get; set; }
    }
}
