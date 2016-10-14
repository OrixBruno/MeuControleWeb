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
            try
            {
                _restSurdo.Request(null, Method.DELETE, "Surdo/" + id);
                ViewBag.Status = "success";
                ViewBag.Message = "Surdo excluido com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
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
            try
            {
                return PartialView("_PartialSurdoLista", _restSurdo.GetLista("Surdo"));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }

        }

        // GET: ControleMapas/Surdo/Editar
        public ActionResult Editar(Int32 id)
        {
            ListaGeneros();
            try
            {
                return View(_restSurdo.GetObjeto("Surdo"));
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
        public ActionResult Adicionar(SurdoViewModel dadoTela)
        {
            try
            {
                _restSurdo.Request(dadoTela, Method.POST, "Surdo");
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
        [HttpPost]
        public ActionResult Editar(SurdoViewModel dadoTela)
        {
            try
            {
                _restSurdo.Request(dadoTela, Method.PUT, "Surdo");
                ViewBag.Message = "Surdo atualizado com sucesso!";
                ViewBag.Status = "success";
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
    }
}