using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Business.Base
{
    interface IBusiness<TClasse>
    {
        void Cadastrar(TClasse dadosTela);

        void Editar(TClasse dadosTela);

        void Excluir(Int32 id);

        TClasse Buscar(Int32 id);

        List<TClasse> Listar();
    }
}
