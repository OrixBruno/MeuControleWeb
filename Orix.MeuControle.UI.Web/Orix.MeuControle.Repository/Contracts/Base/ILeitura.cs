using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Repository.Contracts.Base
{
    interface ILeitura<TClasse>
    {
        TClasse Buscar(Int32 id);

        List<TClasse> Listar();
    }
}
