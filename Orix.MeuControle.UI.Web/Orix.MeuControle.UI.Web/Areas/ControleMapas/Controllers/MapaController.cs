using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using System;
using System.Web.Mvc;
using FastMapper;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using RestSharp;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class MapaController : Controller
    {
        RestApi<LetraViewModel> _letraRest = new RestApi<LetraViewModel>();
        RestApi<SaidaViewModel> _saidaRest = new RestApi<SaidaViewModel>();
        RestApi<TerritorioViewModel> _territorioRest = new RestApi<TerritorioViewModel>();
        RestApi<MapaViewModel> _mapaRest = new RestApi<MapaViewModel>();

        #region METODOS
        private void CarregarSelectLists()
        {
            ViewBag.SelectLetras = new SelectList(_letraRest.GetLista("Letra"), "ID", "Letra", "Selecione...");
            ViewBag.SelectSaidas = new SelectList(_saidaRest.GetLista("Saida"), "ID", "Local", "Selecione...");
            ViewBag.SelectTerritorios = new SelectList(_territorioRest.GetLista("Territorio"), "ID", "Nome", "Selecione...");
        }
        //private void CarregarEstadosCidades()
        //{
        //    using (StreamReader sr = new StreamReader(Server.MapPath("~/json/City.json")))
        //    {
        //        var listaEstadosCidades = JsonConvert.DeserializeObject<ListaEstadosCidades>(sr.ReadToEnd());

        //        using (StreamReader sr2 = new StreamReader(Server.MapPath("~/json/Estate.json")))
        //        {
        //            var estados = JsonConvert.DeserializeObject<ListaEstados>(sr2.ReadToEnd());
        //        }
        //    }
        //}
        #endregion

        #region GET
        public ActionResult Adicionar()
        {
            CarregarSelectLists();
            return View();
        }
        public ActionResult Editar(Int32 id)
        {
            CarregarSelectLists();
            return View(_mapaRest.GetObjeto("Mapa/" + id));

        }
        public ActionResult Excluir(Int32 id)
        {
            ViewBag.Message = "Mapa excluido com sucesso!" + _mapaRest.Request(null,Method.DELETE, "Mapa/" + id);
            ViewBag.Status = "success";

            return PartialView("_PartialAlerta");
        }
        #endregion

        #region POST
        [HttpPost]
        public ActionResult Adicionar(MapaViewModel mapaTela)
        {
            ViewBag.Status = "success";
            ViewBag.Message = "Mapa cadastrado com sucesso!" + _mapaRest.Request(mapaTela,Method.POST,"Mapa");
            return PartialView("_PartialAlerta");
        }
        [HttpPost]
        public ActionResult AdicionarImagem()
        {
            var file = Request.Files["Imagem"];
            var id = Request.Form["Id"];

            return null;
        }
        [HttpPost]
        public ActionResult Editar(MapaViewModel mapaTela)
        {
                _mapaRest.Request(mapaTela,Method.PUT, "Mapa");
                ViewBag.Status = "success";
                ViewBag.Message = "Mapa atualizado com sucesso!";
                return PartialView("_PartialAlerta");
        }
        #endregion

        #region IMPRESSAO
        public ActionResult Impressao()
        {
            return View();
        }
        public ActionResult ConsultarMapa(String letra, String codigo)
        {
            var json = new
            {
                Letra = "",
                Codigo = 10
            };

            return PartialView("_PartialMapaImprimir", json);
        }
        #endregion

        #region CONFIGURACOES
        public ActionResult Configuracoes()
        {
            return View();
        }

        public ActionResult ListaMunicipios()
        {
            return View();
        }
        #endregion
    }
}