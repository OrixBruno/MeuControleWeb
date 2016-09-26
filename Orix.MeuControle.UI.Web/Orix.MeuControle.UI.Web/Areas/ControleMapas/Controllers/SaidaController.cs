using FastMapper;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class SaidaController : Controller
    {
        RestApi<SaidaViewModel> _saidaRest = new RestApi<SaidaViewModel>();
        // GET: ControleMapas/Saida
        public ActionResult Index()
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

            ViewBag.Status = "success";
            ViewBag.Message = "Saída cadastrada com sucesso!" + _saidaRest.Request(saidaTela, Method.POST, "Saida");
            return PartialView("_PartialAlerta");
        }
        // GET: ControleMapas/Saida/Lista
        public ActionResult Lista()
        {
            return PartialView("_PartialLista", _saidaRest.GetLista("Saida"));
        }
        // GET: ControleMapas/Saida/Editar/5
        public ActionResult Editar(int id)
        {
            TempData.Add("Action", "Editar");
            return PartialView("_PartialSaidaAdicionar", _saidaRest.GetObjeto("Saida/" + id));
        }

        // POST: ControleMapas/Saida/Editar/5
        [HttpPost]
        public ActionResult Editar(SaidaViewModel saidaTela)
        {
            ViewBag.Status = "success";
            ViewBag.Message = "Saída atualizada com sucesso!" + _saidaRest.Request(saidaTela, Method.PUT, "Saida");
            return PartialView("_PartialAlerta");
        }

        // GET: ControleMapas/Saida/Excluir/5
        public ActionResult Excluir(int id)
        {

            ViewBag.Status = "success";
            ViewBag.Message = "Saída excluida com sucesso!" + _saidaRest.Request(null, Method.DELETE, "Saida/" + id);
            return PartialView("_PartialAlerta");
        }
    }
}
