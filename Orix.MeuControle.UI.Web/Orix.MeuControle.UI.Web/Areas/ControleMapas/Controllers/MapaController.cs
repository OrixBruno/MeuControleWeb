using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using Orix.MeuControle.Business;
using System;
using System.Web.Mvc;
using FastMapper;
using Orix.MeuControle.Domain.Mapa;
using System.IO;
using Orix.MeuControle.UI.Web.json;
using Newtonsoft.Json;
using System.Web;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class MapaController : Controller
    {
        MapaBusiness _negocios = new MapaBusiness();

        #region METODOS
        private void CarregarSelectLists()
        {
            ViewBag.SelectLetras = new SelectList(new LetraBusiness().Listar(), "ID", "Letra", "Selecione...");
            ViewBag.SelectSaidas = new SelectList(new SaidaBusiness().Listar(), "ID", "Local", "Selecione...");
            ViewBag.SelectTerritorios = new SelectList(new TerritorioBusiness().Listar(), "ID", "Nome", "Selecione...");
        }
        private void CarregarEstadosCidades()
        {
            using (StreamReader sr = new StreamReader(Server.MapPath("~/json/City.json")))
            {
                var listaEstadosCidades = JsonConvert.DeserializeObject<ListaEstadosCidades>(sr.ReadToEnd());

                using (StreamReader sr2 = new StreamReader(Server.MapPath("~/json/Estate.json")))
                {
                    var estados = JsonConvert.DeserializeObject<ListaEstados>(sr2.ReadToEnd());
                }
            }
        }
        #endregion

        #region GET
        public ActionResult Adicionar()
        {
            CarregarSelectLists();
            return View();
        }
        public ActionResult Editar(int id)
        {
            CarregarSelectLists();
            try
            {
                return View(TypeAdapter.Adapt<MapaViewModel>(_negocios.Buscar(id)));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        public ActionResult Excluir(Int32 id)
        {
            try
            {
                _negocios.Excluir(id);
                ViewBag.Status = "success";
                ViewBag.Message = "Mapa excluido com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        #endregion

        #region POST
        [HttpPost]
        public ActionResult Adicionar(MapaViewModel mapaTela)
        {
            try
            {
                //TempData.Add("MapaID",_negocios.Adicionar(TypeAdapter.Adapt<MapaDomainModel>(mapaTela)).ID);

                ViewBag.MapaID = 1;
                ViewBag.Status = "success";
                ViewBag.Message = "Mapa cadastrado com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
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
            try
            {
                ViewBag.Status = "success";
                ViewBag.Message = "Surdo atualizado com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
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