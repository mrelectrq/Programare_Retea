using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laborator3
{
    public class RVT_ApiRequest
    {
        private static HttpClientHandler handler = new HttpClientHandler();
        private static HttpClient client;
       public RVT_ApiRequest()
        {
    //        var cert = new X509Certificate2(Path.Combine
    //("D:\\C#_projects\\Remote_Vote_System\\Certs\\WebCert", "web-certificate.pfx"), "ar4iar4i");
            //var proxy = new WebProxy()
            //{
            //    Address = new Uri($"http://50.226.151.5:80"),
            //    BypassProxyOnLocal = false,
            //    UseDefaultCredentials = true,
            //};   


            //handler.ClientCertificates.Add(cert);
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.AllowAutoRedirect = true;
            //handler.Proxy = proxy;
            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44383/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //handler.CookieContainer.Add(new Cookie("session_id", "4eec00020f8b76651015fb7118b63b02","/"));
            
        }

        public string OptionMeth()
        {
            var request = new HttpRequestMessage()
            {

                Method = HttpMethod.Options,

            };
            var response = client.SendAsync(request);

            try
            {
                var response_message = response.Result.Headers;
                return response_message.ToString();
            }
            catch (AggregateException e)
            {
                return "Eroare de raspuns";
            }

        }

        public string GetMeth()
        {
            var response = client.GetAsync("api/Register");
            try
            {
                var response_message = response.Result.Content.ReadAsStringAsync();
                return response_message.Result;
            }
            catch (AggregateException e) 
            {
                return "Eroare de raspuns";
            }
        }
        public string POSTMeth()
        {
            var request_message = new StringContent("data", Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/Register", request_message);
            
            try
            {
               var response_message = response.Result.Content.ReadAsStringAsync();
                return response_message.Result;  
            }
            catch(AggregateException e)
            {
                return "Eroare de raspuns";
            }

        }
        public string HeadMeth()
        {
            var request = new HttpRequestMessage()
            {

                Method = HttpMethod.Head,

            };
            var response = client.SendAsync(request);

            try
            {
                var response_message = response.Result.Headers;
                return response_message.ToString();
            }
            catch (AggregateException e)
            {
                return "Eroare de raspuns";
            }
        }

    }
}
