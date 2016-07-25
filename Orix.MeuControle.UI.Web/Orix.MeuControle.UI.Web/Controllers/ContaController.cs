using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Adicionar()
        {
            return View();
        }
    }
}