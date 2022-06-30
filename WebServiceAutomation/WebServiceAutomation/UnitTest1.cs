using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace WebServiceAutomation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HttpClient httpClient = new HttpClient(); //Comes from system.Net.Http
            httpClient.Dispose(); //Closes the connection and release the resource

        }
    }
}
