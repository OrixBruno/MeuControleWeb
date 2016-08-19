using FastMapper;
using Orix.MeuControle.Business;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class TerritorioController : Controller
    {
        TerritorioBusiness _negocios = new TerritorioBusiness();
        // GET: ControleMapas/Territorio
        public ActionResult Index()
        {
            return View();
        }

        // GET: ControleMapas/Territorio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ControleMapas/Territorio/Adicionar
        public ActionResult Adicionar()
        {
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
        // GET: ControleMapas/Territorio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ControleMapas/Territorio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ControleMapas/Territorio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ControleMapas/Territorio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
