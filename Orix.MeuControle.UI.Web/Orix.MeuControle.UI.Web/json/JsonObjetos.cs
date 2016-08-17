using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.UI.Web.json
{
    public class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
    }

    public class EstadoCidades
    {
        public List<Cidade> cidades { get; set; }
    }

    public class ListaEstadosCidades
    {
        public List<EstadoCidades> Estados { get; set; }
    }

    //-------------------------------------------------------------

    public class Estado
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }
    public class ListaEstados
    {
        public List<Estado> estados { get; set; }
    }
}