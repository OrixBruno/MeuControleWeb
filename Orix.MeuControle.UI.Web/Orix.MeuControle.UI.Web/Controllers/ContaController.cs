using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orix.MeuControle.UI.Web.ViewModels;

namespace Orix.MeuControle.UI.Web.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Editar(Int32 id)
        {
            var conta = new ContaViewModel()
            {
                ID = 1,
                Nome = "Bruno",
                Ativa = true,
                Saldo = 1500
            };
            TempData.Add("FuncaoFormulario", "Atualizar");
            return View(conta);
        }
        public ActionResult Detalhes(Int32 id)
        {
            return View();
        }
        public ActionResult Excluir(Int32 id)
        {
            return RedirectToAction("Listar");
        }
        public ActionResult Adicionar()
        {
            TempData.Add("FuncaoFormulario", "Adicionar");
            return View();
        }
        public ActionResult Listar()
        {

            return View();
        }

        public PartialViewResult ObterDados()
        {
            var lista = new List<ContaViewModel>
            {
                new ContaViewModel()
                {
                    ID = 1,
                    Nome = "Bruno",
                    Ativa = true,
                    Saldo = 1500
                },
                new ContaViewModel()
                {
                    ID = 2,
                    Nome = "FElipe",
                    Ativa = true,
                    Saldo = 2000
                }
            };

            return PartialView("_ObterDados",lista);
        }

        //POST
        [HttpPost]
        public ActionResult Adicionar(ContaViewModel dadosTela)
        {
            return JavaScript("location.reload(true)");
        }

        [HttpPost]
        public ActionResult Editar(ContaViewModel dadosTela)
        {
            return JavaScript("window.location = '/Conta/Listar'");
        }
    }
}