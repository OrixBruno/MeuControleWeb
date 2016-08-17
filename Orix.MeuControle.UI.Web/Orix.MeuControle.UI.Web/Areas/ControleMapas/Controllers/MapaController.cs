using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using Orix.MeuControle.Business;
using System;
using System.Web.Mvc;
using FastMapper;
using Orix.MeuControle.Domain.Mapa;
using System.Collections.Generic;
using System.IO;
using Orix.MeuControle.UI.Web.json;
using Newtonsoft.Json;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class MapaController : Controller
    {
        MapaBusiness _negocios = new MapaBusiness();

        #region METODOS
        private List<LetraViewModel> ObterLetras()
        {
            return TypeAdapter.Adapt<List<LetraViewModel>>(_negocios.LetraLista());
        }
        private List<SaidaViewModel> ObterSaidas()
        {
            return TypeAdapter.Adapt<List<SaidaViewModel>>(_negocios.SaidaLista());
        }
        private List<TerritorioViewModel> ObterTerritorios()
        {
            return TypeAdapter.Adapt<List<TerritorioViewModel>>(_negocios.TerritorioLista());
        }
        private void CarregarSelectLists()
        {
            ViewBag.SelectLetras = new SelectList(ObterLetras(), "ID", "Letra", "Selecione...");
            ViewBag.SelectSaidas = new SelectList(ObterSaidas(), "ID", "Local", "Selecione...");
            ViewBag.SelectTerritorios = new SelectList(ObterTerritorios(), "ID", "Nome", "Selecione...");
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

        #region MAPA
        #region GET
        public ActionResult Adicionar()
        {
            CarregarSelectLists();
            return View();
        }
        public ActionResult Editar()
        {
            CarregarSelectLists();
            return View();
        }
        public ActionResult Excluir()
        {
            return View();
        }
        #endregion

        #region POST
        [HttpPost]
        public ActionResult Adicionar(MapaViewModel mapaTela)
        {
            try
            {
                _negocios.Adicionar(TypeAdapter.Adapt<MapaDomainModel>(mapaTela));
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
        public ActionResult Editar(MapaViewModel mapaTela)
        {
            try
            {
                ViewBag.Status = "success";
                ViewBag.Message = "Surdo cadastrado com sucesso!";
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
        #endregion

        #region LETRA
        #region GET
        // GET: ControleMapas/Mapa/Letra
        public ActionResult Letra()
        {
            return PartialView("_PartialLetraAdicionar");
        }
        #endregion
        #region POST
        [HttpPost]
        public ActionResult Letra(LetraViewModel letraTela)
        {
            try
            {
                _negocios.LetraCadastrar(TypeAdapter.Adapt<LetraDomainModel>(letraTela));
                ViewBag.Status = "success";
                ViewBag.Message = "Letra adicionada com sucesso!";
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
        #endregion

        #region SAIDA
        #region GET
        // GET: ControleMapas/Mapa/Saida
        public ActionResult Saida()
        {
            return PartialView("_PartialSaidaAdicionar");
        }
        #endregion
        #region POST
        [HttpPost]
        public ActionResult Saida(SaidaViewModel saidaTela)
        {
            try
            {
                _negocios.SaidaCadastrar(TypeAdapter.Adapt<SaidaDomainModel>(saidaTela));
                ViewBag.Status = "success";
                ViewBag.Message = "Saída cadastrada com sucesso!";
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
        #endregion

        #region TERRITORIO
        #region GET
        // GET: ControleMapas/Mapa/Territorio
        public ActionResult Territorio()
        {
            return PartialView("_PartialTerritorioAdicionar");
        }
        #endregion
        #region POST
        [HttpPost]
        public ActionResult Territorio(TerritorioViewModel territorioTela)
        {
            try
            {
                _negocios.TerritorioCadastrar(TypeAdapter.Adapt<TerritorioDomainModel>(territorioTela));
                ViewBag.Status = "success";
                ViewBag.Message = "Território cadastrado com sucesso!";
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
            ViewBag.LetraList = ObterLetras();
            ViewBag.SaidaList = ObterSaidas();
            ViewBag.TerritorioList = ObterTerritorios();

            return View();
        }
        #endregion

        public ActionResult ListaMunicipios()
        {
            return View();
        }
    }
}