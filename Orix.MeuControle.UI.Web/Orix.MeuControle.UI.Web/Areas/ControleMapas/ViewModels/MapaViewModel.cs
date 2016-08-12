using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels
{
    public class MapaViewModel
    {
        public Int32 ID { get; set; }

        public String Territorio { get; set; }

        public String Letra { get; set; }

        public Int32 Numero { get; set; }

        public String Cor { get; set; }

        public String SaidaCampo { get; set; }

        public String UrlFoto { get; set; }
    }
}