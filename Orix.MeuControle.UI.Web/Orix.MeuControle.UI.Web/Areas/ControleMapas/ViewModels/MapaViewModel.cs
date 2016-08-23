using System;
using System.Web;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels
{
    public class MapaViewModel
    {
        public Int32 ID { get; set; }
        public Int32 Numero { get; set; }
        public String Cor { get; set; }

        public String UrlFoto { get; set; }
        public HttpPostedFile FileFoto { get; set; }

        public Int32 IdLetra { get; set; }
        public Int32 IdSaida { get; set; }
        public Int32 IdTerritorio { get; set; }

        public virtual LetraViewModel Letra { get; set; }
        public virtual SaidaViewModel Saida { get; set; }
        public virtual TerritorioViewModel Territorio { get; set; }
    }
}