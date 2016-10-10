using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.UI.Web.ViewModels
{
    public class AuthorizationViewModel
    {
        public const String grant_type = "password";
        public String username { get; set; }
        public String password { get; set; }
    }
}