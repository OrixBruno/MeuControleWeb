using FastMapper;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using Orix.MeuControle.UI.Web;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RestSharp;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class LetraController : Controller
    {
        RestApi<LetraViewModel> _restfull = new RestApi<LetraViewModel>();

        // GET: ControleMapas/Letra/Adicionar
        public ActionResult Adicionar()
        {
            TempData.Add("Action", "Adicionar");
            return PartialView("_PartialLetraAdicionar");
        }
        // GET: ControleMapas/Letra/Editar/1
        public ActionResult Editar(int id)
        {
            TempData.Add("Action", "Editar");
            return PartialView("_PartialLetraAdicionar", _restfull.GetObjeto("Letra/" + id));
        }
        // POST: ControleMapas/Letra/Editar
        [HttpPost]
        public ActionResult Editar(LetraViewModel letraTela)
        {
            ViewBag.Status = "success";
            ViewBag.Message = "Letra atualizada com sucesso! \n" + _restfull.Request(letraTela,Method.PUT, "Letra");
            return PartialView("_PartialAlerta");

            //ViewBag.Message = ex.Message;
            //ViewBag.Status = "danger";
            //return PartialView("_PartialAlerta");

        }
        // POST: ControleMapas/Letra/Adicionar
        [HttpPost]
        public ActionResult Adicionar(LetraViewModel letraTela)
        {
            ViewBag.Message = _restfull.Request(letraTela, Method.POST, "Letra");
            ViewBag.Status = "success";
            return PartialView("_PartialAlerta");
        }
        // GET: ControleMapas/Letra/Lista
        public ActionResult Lista()
        {
            return PartialView("_PartialLista", _restfull.GetLista("Letra"));
        }

        // GET: ControleMapas/Letra/Excluir/5
        public ActionResult Excluir(Int32 id)
        {
            ViewBag.Status = "success";
            ViewBag.Message = "Letra excluido com sucesso!"+ _restfull.Request(null,Method.DELETE, "Letra/" + id);
            return PartialView("_PartialAlerta");
        }
    }
}