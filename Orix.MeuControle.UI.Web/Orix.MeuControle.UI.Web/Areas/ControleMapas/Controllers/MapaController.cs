using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class MapaController : Controller
    {
        // GET: ControleMapas/Mapa
        public ActionResult Impressao()
        {
            return View();
        }
        public ActionResult ConsultarMapa(String letra, String codigo)
        {
            var json = new {
                Letra = "",
                Codigo = 10
            };

            return PartialView("_PartialMapaImprimir", json);
        }
    }
}