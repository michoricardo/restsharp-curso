using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceAutomation.GetEndPoint
{
    [TestClass]
    public class TestGetEndpoint
    {
        private string getUrl = "http://localhost:8080/laptop-bag/webapi/api/all"; //url de localhost que tenemos preparado desde el inicio
        [TestMethod]
        public void TestGetAllEndPoint()
        {
        //Create http client
        HttpClient httpClient = new HttpClient();
        //Create the request and execute it
        httpClient.GetAsync(getUrl);
        //Close the connection
        httpClient.Dispose();    
        }

        [TestMethod]
        public void TestGetAllEndpointWithUri()
        {
            //Create http client
            //HttpClient es la clase de c# que permite enviar y recibir peticiones HTTP por medio de un URI
            HttpClient httpClient = new HttpClient();
            //Create request and execute it
            Uri getUri = new Uri(getUrl);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // recover the status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code => " + statusCode);
            Console.WriteLine("Status code => " + (int)statusCode);

            //Response data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);
            httpClient.Dispose();
        }
        [TestMethod]
        public void TestGetAllEnpointInJsonFormat()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // recover the status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code => " + statusCode);
            Console.WriteLine("Status code => " + (int)statusCode);

            //Response data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);
            //Close the connection
            httpClient.Dispose();

        }

        [TestMethod]
        public void TestGetAllEnpointInXmlFormat()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/xml");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // recover the status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code => " + statusCode);
            Console.WriteLine("Status code => " + (int)statusCode);

            //Response data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);
            //Close the connection
            httpClient.Dispose();

        }


        [TestMethod]
        public void TestGetEndpointUsingSendAsync()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(getUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);
            
           
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // recover the status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code => " + statusCode);
            Console.WriteLine("Status code => " + (int)statusCode);

            //Response data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);
            //Close the connection
            httpClient.Dispose();

        }

        [TestMethod]
        public void TestUsingStatement()
        {
            using (HttpClient httpClient = new HttpClient())
            {

                using(HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");


                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using(HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        // recover the status code
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        Console.WriteLine("Status code => " + statusCode);
                        Console.WriteLine("Status code => " + (int)statusCode);

                        //Response data
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        Console.WriteLine(data); 

                    }
                }

            }
        }

    }
}
