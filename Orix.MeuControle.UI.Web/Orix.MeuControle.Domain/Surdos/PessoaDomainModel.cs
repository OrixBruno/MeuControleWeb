using System;

namespace Orix.MeuControle.Domain.Surdos
{
    public sealed class PessoaDomainModel
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public String Genero { get; set; }
        public Int32 Idade { get; set; }

        public String Rua { get; set; }
        public Int32 Numero { get; set; }
        public String Bairro { get; set; }

        public String Observacao { get; set; }
    }
}
