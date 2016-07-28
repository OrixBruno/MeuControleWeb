using Orix.MeuControle.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Controllers
{
    public class ReceitaController : Controller
    {
        #region Listas 
        private List<ContaViewModel> BuscarContas()
        {
            return new List<ContaViewModel>() {
                new ContaViewModel(){
                    Ativa = true,
                    ID = 1,
                    Nome = "Conta Corrente",
                    Saldo = 5000.0
                },
                new ContaViewModel(){
                    Ativa = true,
                    ID = 2,
                    Nome = "Conta Poupança",
                    Saldo = 5000.0
                },
                new ContaViewModel(){
                    Ativa = true,
                    ID = 3,
                    Nome = "Vale Refeição",
                    Saldo = 5000.0
                }
            };
        }
        private List<CategoriaViewModel> BuscarCategorias()
        {
            return new List<CategoriaViewModel>()
            {
                new CategoriaViewModel()
                {
                    ID = 1,
                    Descricao = "Lazer"
                },
                new CategoriaViewModel()
                {
                    ID = 2,
                    Descricao = "Saúde"
                },
                new CategoriaViewModel()
                {
                    ID = 3,
                    Descricao = "Casa"
                },
            };
        }
        private List<TipoViewModel> BuscarTipos()
        {
            return new List<TipoViewModel>()
            {
                new TipoViewModel()
                {
                    ID = 1,
                    Descricao = "Despesa"
                },
                new TipoViewModel()
                {
                    ID = 2,
                    Descricao = "Receita"
                },
                new TipoViewModel()
                {
                    ID = 3,
                    Descricao = "Transferência"
                }
            };
        }

        #endregion

        #region GET ---------------------------------------
        public ActionResult Listar()
        {
            return View();
        }

        public ActionResult Adicionar()
        {
            ViewBag.Contas = BuscarContas();
            ViewBag.Categorias = BuscarCategorias();
            ViewBag.Tipos = BuscarTipos();

            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }
        #endregion

        #region POST ------------------------------
        [HttpPost]
        public ActionResult Adicionar(ReceitaViewModel dadosTela)
        {
            return RedirectToAction("Adicionar");
        }
        #endregion
    }
}