using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Domain.Mapa
{
    public class FotoDomainModel
    {
        public Int32 ID { get; set; }
        public String URL { get; set; }
        public Int32 IdMapa { get; set; }
        public String Descricao { get; set; }

        public Byte ImgByte { get; set; }

        public virtual MapaDomainModel Mapa { get; set; }
    }
}
