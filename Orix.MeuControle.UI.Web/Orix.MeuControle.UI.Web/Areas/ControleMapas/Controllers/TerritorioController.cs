using FastMapper;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class TerritorioController : Controller
    {
        RestApi<TerritorioViewModel> _territorioRest = new RestApi<TerritorioViewModel>();
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
            ViewBag.Status = "success";
            ViewBag.Message = "Território cadastrado com sucesso!" + _territorioRest.Request(territorioTela, Method.POST, "Territorio");
            return PartialView("_PartialAlerta");
        }
        // GET: ControleMapas/Territorio/Lista
        public ActionResult Lista()
        {
            _territorioRest.Token = HttpContext.Session["Token"].ToString();
            return PartialView("_PartialLista", _territorioRest.GetLista("Territorio"));
        }
        // GET: ControleMapas/Territorio/Editar/5
        public ActionResult Editar(int id)
        {
            TempData.Add("Action", "Editar");
            return PartialView("_PartialTerritorioAdicionar", _territorioRest.GetObjeto("Territorio"));
        }

        // POST: ControleMapas/Territorio/Editar/5
        [HttpPost]
        public ActionResult Editar(TerritorioViewModel territorioTela)
        {
            ViewBag.Status = "success";
            ViewBag.Message = "Território atualizado com sucesso!" + _territorioRest.Request(territorioTela, Method.PUT, "Territorio");
            return PartialView("_PartialAlerta");
        }

        // GET: ControleMapas/Territorio/Excluir/5
        public ActionResult Excluir(Int32 id)
        {
                ViewBag.Status = "success";
                ViewBag.Message = "Território excluido com sucesso!"+ _territorioRest.Request(null,Method.DELETE, "Territorio");
                return PartialView("_PartialAlerta");
        }
    }
}
