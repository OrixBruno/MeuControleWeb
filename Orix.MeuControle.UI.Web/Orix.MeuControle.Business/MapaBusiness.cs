using System;
using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation;
using System.Collections.Generic;

namespace Orix.MeuControle.Business
{
    public class MapaBusiness
    {
        LetraRepository _letraRepository = new LetraRepository();
        SaidaRepository _saidaRepository = new SaidaRepository();
        TerritorioRepository _territorioRepository = new TerritorioRepository();
        MapaRepository _mapaRepository = new MapaRepository();

        #region LETRA
        public void LetraCadastrar(LetraDomainModel dadosTela)
        {
            _letraRepository.Cadastrar(dadosTela);
        }
        public List<LetraDomainModel> LetraLista()
        {
            return _letraRepository.Listar();
        }
        public void LetraEdita(LetraDomainModel dadosTela)
        {
            _letraRepository.Editar(dadosTela);
            //_letraRepository.Buscar();
            //_letraRepository.Excluir();
            //_letraRepository.
        }
        #endregion
        public void SaidaCadastrar(SaidaDomainModel dadosTela)
        {
            _saidaRepository.Cadastrar(dadosTela);
        }
        public void TerritorioCadastrar(TerritorioDomainModel dadosTela)
        {
            _territorioRepository.Cadastrar(dadosTela);
        }

        public void Adicionar(MapaDomainModel mapaDomainModel)
        {
            _mapaRepository.Cadastrar(mapaDomainModel);
        }
        #region LISTAS
        public List<SaidaDomainModel> SaidaLista()
        {
            return _saidaRepository.Listar();
        }

        public List<TerritorioDomainModel> TerritorioLista()
        {
            return _territorioRepository.Listar();
        }
        #endregion
    }
}
