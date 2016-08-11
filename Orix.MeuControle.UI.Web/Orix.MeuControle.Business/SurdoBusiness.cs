using Orix.MeuControle.Domain.Surdos;
using Orix.MeuControle.Repository.Implementation;
using System;
using System.Collections.Generic;

namespace Orix.MeuControle.Business
{
    public class SurdoBusiness
    {
        PessoaRepository _repository = new PessoaRepository();

        #region Validações
        private void Validar(PessoaDomainModel surdoTela)
        {
            if (surdoTela.Idade < 5)
                throw new Exception("Idade minima de 5 anos");
        }
        #endregion

        public void Cadastrar(PessoaDomainModel surdoTela)
        {
            Validar(surdoTela);
            _repository.Cadastrar(surdoTela);
        }
        public List<PessoaDomainModel> Lista()
        {
            return _repository.Listar();
        }
        public void Editar(PessoaDomainModel surdoTela)
        {
            Validar(surdoTela);
            _repository.Editar(surdoTela);
        }

        public PessoaDomainModel Buscar(Int32 id)
        {
            return _repository.Buscar(id);
        }

        public void Excluir(Int32 id)
        {
            _repository.Excluir(id);
        }
    }
}
