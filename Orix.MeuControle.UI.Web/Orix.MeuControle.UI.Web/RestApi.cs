using Newtonsoft.Json;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using Orix.MeuControle.UI.Web.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web;

namespace Orix.MeuControle.UI.Web
{
    public static class Token
    { 
        public static void setToken(String token)
        {
            HttpContext.Current.Session["Token"] = token;
        }
        public static String getToken()
        {
            return HttpContext.Current.Session["Token"].ToString();
        }
    }

    public class RestApi<TClasse>
    {
        private RestClient _cliente;
        private const String URL_BASE = "http://localhost:81/api/v1/";
        private const String API_BASE = "http://localhost:81/";
 
        //METODOS DE REQUEST
        //GET --------------->>>>>>
        public TClasse GetObjeto(String action)
        {
            _cliente = new RestClient(URL_BASE + action);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization",Token.getToken());
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "OK")
                return JsonConvert.DeserializeObject<TClasse>(response.Content);

            throw new Exception(response.Content);
        }
        public List<TClasse> GetLista(String action)
        {
            _cliente = new RestClient(URL_BASE + action);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", Token.getToken());
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "OK")
                return JsonConvert.DeserializeObject<List<TClasse>>(response.Content);

            throw new Exception(response.Content);
        }
        //POST, PUT, DELETE
        public virtual IRestResponse Request(TClasse objeto, Method metodo, String action)
        {
            _cliente = new RestClient(URL_BASE + action);
            var request = new RestRequest(metodo);
            request.AddJsonBody(objeto);
            request.AddHeader("Authorization", Token.getToken());
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "OK")
                return response;

            throw new Exception(response.Content);
        }
        public virtual AuthorizationViewModel RequestToken(AuthorizationViewModel objeto, Method metodo, String action)
        {
            _cliente = new RestClient(API_BASE + action);
            var request = new RestRequest(metodo);
            request.AddParameter("grant_type", objeto.grant_type);
            request.AddParameter("username", objeto.username);
            request.AddParameter("password", objeto.password);
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "OK")
                return JsonConvert.DeserializeObject<AuthorizationViewModel>(response.Content);

            throw new Exception(response.Content);
        }
    }
}