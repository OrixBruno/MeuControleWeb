using Orix.MeuControle.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class Genero
    {
        public String Descricao { get; set; }
    }

    public class SurdoController : Controller
    {
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
        // GET: ControleMapas/Surdo
        public ActionResult Adicionar()
        {
            ListaGeneros();

            return View();
        }
        #endregion

        #region POST
        [HttpPost]
        public ActionResult Adicionar(PessoaViewModel dadoTela)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Editar()
        {
            return View();
        }
        #endregion

        #region DELETE
        [HttpDelete]
        public ActionResult Excluir()
        {
            return View();
        }
        #endregion
    }
}