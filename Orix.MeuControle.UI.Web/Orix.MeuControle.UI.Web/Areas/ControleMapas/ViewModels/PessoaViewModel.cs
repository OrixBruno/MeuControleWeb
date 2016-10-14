using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public Int32 Codigo { get; set; }

        [Required(ErrorMessage ="Nome obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Genêro obrigatório")]
        public String Genero { get; set; }

        public Int32 Idade { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório")]
        public String Rua { get; set; }

        [Required(ErrorMessage = "Numero obrigatório")]
        public Int32 Numero { get; set; }

        [Required(ErrorMessage = "Bairro obrigatório")]
        public String Bairro { get; set; }

        public String Observacao { get; set; }
        public Int32 ID_Mapa { get; set; }
    }
}