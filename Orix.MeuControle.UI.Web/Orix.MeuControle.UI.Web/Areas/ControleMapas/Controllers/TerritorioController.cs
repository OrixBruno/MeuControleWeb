using FastMapper;
using Orix.MeuControle.Business;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class TerritorioController : Controller
    {
        TerritorioBusiness _negocios = new TerritorioBusiness();

        // GET: ControleMapas/Territorio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ControleMapas/Territorio/Adicionar
        public ActionResult Adicionar()
        {
            TempData.Add("Action", "Adicionar");
            return PartialView("_PartialTerritorioAdicionar");
        }

        // POST: ControleMapas/Territorio/Adicionar
        [HttpPost]
        public ActionResult Adicionar(TerritorioViewModel territorioTela)
        {
            try
            {
                _negocios.Cadastrar(TypeAdapter.Adapt<TerritorioDomainModel>(territorioTela));
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
        // GET: ControleMapas/Territorio/Lista
        public ActionResult Lista()
        {
            var lista = TypeAdapter.Adapt<List<TerritorioViewModel>>(_negocios.Listar());
            return PartialView("_PartialLista", lista);
        }
        // GET: ControleMapas/Territorio/Editar/5
        public ActionResult Editar(int id)
        {
            try
            {
                TempData.Add("Action", "Editar");
                return PartialView("_PartialTerritorioAdicionar", TypeAdapter.Adapt<TerritorioViewModel>(_negocios.Buscar(id)));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }

        // POST: ControleMapas/Territorio/Editar/5
        [HttpPost]
        public ActionResult Editar(TerritorioViewModel territorioTela)
        {
            try
            {
                _negocios.Editar(TypeAdapter.Adapt<TerritorioDomainModel>(territorioTela));
                ViewBag.Status = "success";
                ViewBag.Message = "Território atualizado com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }

        // GET: ControleMapas/Territorio/Excluir/5
        public ActionResult Excluir(Int32 id)
        {
            try
            {
                _negocios.Excluir(id);
                ViewBag.Status = "success";
                ViewBag.Message = "Território excluido com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
    }
}
