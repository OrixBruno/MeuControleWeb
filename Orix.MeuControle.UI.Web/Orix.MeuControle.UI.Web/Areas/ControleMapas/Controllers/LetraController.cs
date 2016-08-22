using FastMapper;
using Orix.MeuControle.Business;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class LetraController : Controller
    {
        LetraBusiness _negocios = new LetraBusiness();

        // GET: ControleMapas/Letra/Adicionar
        public ActionResult Adicionar()
        {
            TempData.Add("Action","Adicionar");
            return PartialView("_PartialLetraAdicionar");
        }
        // GET: ControleMapas/Letra/Editar/1
        public ActionResult Editar(int id)
        {
            try
            {
                TempData.Add("Action", "Editar");
                return PartialView("_PartialLetraAdicionar", TypeAdapter.Adapt<LetraViewModel>(_negocios.Buscar(id)));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }            
        }
        // POST: ControleMapas/Letra/Editar
        [HttpPost]
        public ActionResult Editar(LetraViewModel letraTela)
        {
            try
            {
                _negocios.Editar(TypeAdapter.Adapt<LetraDomainModel>(letraTela));
                ViewBag.Status = "success";
                ViewBag.Message = "Letra atualizada com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        // POST: ControleMapas/Letra/Adicionar
        [HttpPost]
        public ActionResult Adicionar(LetraViewModel letraTela)
        {
            try            
            {
                _negocios.Cadastrar(TypeAdapter.Adapt<LetraDomainModel>(letraTela));
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
        // GET: ControleMapas/Letra/Lista

        public ActionResult Lista()
        {
            var lista = TypeAdapter.Adapt<List<LetraViewModel>>(_negocios.Listar());
            return PartialView("_PartialLista", lista);
        }

        // GET: ControleMapas/Letra/Excluir/5
        public ActionResult Excluir(Int32 id)
        {
            try
            {
                _negocios.Excluir(id);
                ViewBag.Status = "success";
                ViewBag.Message = "Letra excluido com sucesso!";
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