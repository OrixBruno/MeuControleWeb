using Newtonsoft.Json;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Orix.MeuControle.UI.Web
{
    public class RestApi<TClasse>
    {
        private RestClient _cliente;
        private const String URL_BASE = "http://www.apiprojetos.somee.com/api/v1/";

        //METODOS DE REQUEST
        //GET --------------->>>>>>
        public TClasse GetObjeto(String action)
        {
            _cliente = new RestClient(URL_BASE + action);
            var request = new RestRequest(Method.GET);
            return JsonConvert.DeserializeObject<TClasse>(_cliente.Execute(request).Content);
        }
        public List<TClasse> GetLista(String action)
        {
            _cliente = new RestClient(URL_BASE + action);
            var request = new RestRequest(Method.GET);
            return JsonConvert.DeserializeObject<List<TClasse>>(_cliente.Execute(request).Content);
        }
        //POST, PUT, DELETE
        public virtual String Request(TClasse objeto, Method metodo, String action)
        {
            _cliente = new RestClient(URL_BASE + action);
            var request = new RestRequest(metodo);
            request.AddJsonBody(objeto);
            return _cliente.Execute(request).Content;
        }
    }
}