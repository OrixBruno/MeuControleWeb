using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.UI.Web.ViewModels
{
    public class ReceitaViewModel
    {
        [Key]
        public Int32 ID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public Double Valor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataEfetuada { get; set; }

        [Required]
        public Boolean Repetir { get; set; }

        [Required]
        public Boolean Efetuada { get; set; }

        [Required]
        [ForeignKey("TipoViewModel")]
        public Int32 TipoID { get; set; }

        [Required]
        [ForeignKey("CategoriaViewModel")]
        public Int32 CategoriaID { get; set; }

        [Required]
        [ForeignKey("ContaViewModel")]
        public Int32 ContaID { get; set; }


        public virtual TipoViewModel TipoViewModel { get; set; }


        public virtual CategoriaViewModel CategoriaViewModel { get; set; }


        public virtual ContaViewModel ContaViewModel { get; set; }
    }
}