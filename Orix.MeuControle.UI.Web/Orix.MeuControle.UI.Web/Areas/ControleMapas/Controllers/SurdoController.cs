using Orix.MeuControle.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FastMapper;
using RestSharp;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    internal class Genero
    {
        public String Descricao { get; set; }
    }

    public class SurdoController : Controller
    {
        RestApi<SurdoViewModel> _restSurdo = new RestApi<SurdoViewModel>();
        #region METODOS
        private void ListaGeneros()
        {
            var listGenero = new List<Genero>() {
                new Genero()
                {
                    Descricao = "Homem"
                },
                new Genero()
                {
                    Descricao = "Mulher"
                },
                new Genero()
                {
                    Descricao = "Casal"
                },
                new Genero()
                {
                    Descricao = "Irmão"
                }
            };
            var selectListGenero = new SelectList(listGenero, "Descricao", "Descricao", "Selecione...");

            if (TempData["Generos"] == null)
            {
                TempData.Add("Generos", selectListGenero);
                return;
            }
            TempData["Generos"] = selectListGenero;
        }
        #endregion

        #region GET
        [HttpGet]
        public ActionResult Excluir(Int32 id)
        {
            ViewBag.Status = "success";
            ViewBag.Message = "Surdo excluido com sucesso!" + _restSurdo.Request(null, Method.DELETE, "Surdo/" + id);
            return PartialView("_PartialAlerta");
        }
        // GET: ControleMapas/Surdo/Adicionar
        public ActionResult Adicionar()
        {
            ListaGeneros();
            return View();
        }
        // GET: ControleMapas/Surdo/Lista
        public ActionResult Lista()
        {
            return View();
        }

        // GET: ControleMapas/Surdo/ObterListaSurdos
        public ActionResult ObterListaSurdos()
        {
            return PartialView("_PartialSurdoLista", _restSurdo.GetLista("Surdo"));
        }

        // GET: ControleMapas/Surdo/Editar
        public ActionResult Editar(Int32 id)
        {
            ListaGeneros();
            return View(_restSurdo.GetObjeto("Surdo"));
        }
        #endregion

        #region POST
        [HttpPost]
        public ActionResult Adicionar(SurdoViewModel dadoTela)
        {
            ViewBag.Status = "success";
            ViewBag.Message = "Surdo cadastrado com sucesso!" + _restSurdo.Request(dadoTela, Method.POST, "Surdo");
            return PartialView("_PartialAlerta");
        }
        [HttpPost]
        public ActionResult Editar(SurdoViewModel dadoTela)
        {
            ViewBag.Message = "Surdo atualizado com sucesso!" + _restSurdo.Request(dadoTela, Method.PUT, "Surdo");
            ViewBag.Status = "success";
            return PartialView("_PartialAlerta");
        }
        #endregion
    }
}