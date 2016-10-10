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
        public String Token { get; set; }
        private const String URL_BASE = "http://localhost:81/api/v1/";
        private const String API_BASE = "http://localhost:81/";
        //METODOS DE REQUEST
        //GET --------------->>>>>>
        public TClasse GetObjeto(String action)
        {
            _cliente = new RestClient(URL_BASE + action);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + Token);
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "200")
                return JsonConvert.DeserializeObject<TClasse>(response.Content);

            throw new Exception(response.Content);
        }
        public List<TClasse> GetLista(String action)
        {
            _cliente = new RestClient(URL_BASE + action);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer "+Token);
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "200")
                return JsonConvert.DeserializeObject<List<TClasse>>(response.Content);

            throw new Exception(response.Content);
        }
        //POST, PUT, DELETE
        public virtual String Request(TClasse objeto, Method metodo, String action)
        {
            _cliente = new RestClient(URL_BASE + action);
            var request = new RestRequest(metodo);
            request.AddJsonBody(objeto);
            request.AddHeader("Authorization", "Bearer " + Token);
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "200")
                return response.Content;

            throw new Exception(response.Content);
        }
        public virtual String RequestToken(TClasse objeto, Method metodo, String action)
        {
            _cliente = new RestClient(API_BASE + action);
            var request = new RestRequest(metodo);
            request.AddJsonBody(objeto);
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "200")
                return response.Content;

            throw new Exception(response.Content);
        }
    }
}