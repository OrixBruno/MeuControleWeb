using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.UI.Web.ViewModels
{
    public class ContaViewModel
    {
        [Key]
        public Int32 ID { get; set; }

        [Required(]
        public String Nome { get; set; }

        [Required]
        public Double Saldo { get; set; }

        [Required]
        public Boolean Ativa { get; set; }
    }
}