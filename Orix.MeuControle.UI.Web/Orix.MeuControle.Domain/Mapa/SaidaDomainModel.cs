using System;
using System.Collections.Generic;

namespace Orix.MeuControle.Domain.Mapa
{
    public class SaidaDomainModel
    {

        public Int32 ID { get; set; }

        public String Local { get; set; }

        public String Logradouro { get; set; }

        public virtual ICollection<MapaDomainModel> ListaMapa { get; set; }
    }
}
