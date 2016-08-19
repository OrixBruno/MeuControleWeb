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
    public class SaidaController : Controller
    {
        SaidaBusiness _negocios = new SaidaBusiness();
        // GET: ControleMapas/Saida
        public ActionResult Index()
        {
            return View();
        }

        // GET: ControleMapas/Saida/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ControleMapas/Saida/Adicionar
        public ActionResult Adicionar()
        {
            return PartialView("_PartialSaidaAdicionar");
        }

        // POST: ControleMapas/Saida/Adicionar
        [HttpPost]
        public ActionResult Adicionar(SaidaViewModel saidaTela)
        {
            try
            {
                _negocios.Cadastrar(TypeAdapter.Adapt<SaidaDomainModel>(saidaTela));
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
        // GET: ControleMapas/Saida/Lista
        public ActionResult Lista()
        {
            var lista = TypeAdapter.Adapt<List<SaidaViewModel>>(_negocios.Listar());
            return PartialView("_PartialLista", lista);
        }
        // GET: ControleMapas/Saida/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ControleMapas/Saida/Edit/5
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

        // GET: ControleMapas/Saida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ControleMapas/Saida/Delete/5
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
