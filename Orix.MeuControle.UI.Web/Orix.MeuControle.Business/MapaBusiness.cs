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

        #region CADASTRAR
        public void LetraCadastrar(LetraDomainModel dadosTela)
        {
            _letraRepository.Cadastrar(dadosTela);
        }

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
        #endregion

        #region LISTAS
        public List<LetraDomainModel> LetraLista()
        {
            return _letraRepository.Listar();
        }

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
