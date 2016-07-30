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

        [Required(ErrorMessage ="Por favor digite seu nome")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Informe o saldo da sua conta")]
        [DataType(DataType.Currency)]
        public Double Saldo { get; set; }

        [Required(ErrorMessage = "Informe se sua conta está ativa ou nao")]
        [Display(Name ="Conta ativa?")]
        public Boolean Ativa { get; set; }
    }
}