﻿using Orix.MeuControle.Domain.Surdos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Repository.Contracts
{
    interface IPessoaRepository: Base.ILeitura<PessoaDomainModel>, Base.IGravacao<PessoaDomainModel>
    {

    }
}
