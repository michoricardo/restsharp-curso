using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MsTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod,TestCategory("Smoke")]
        public void TestMethod1()
        {
            Console.WriteLine("Test Method one");

        }
        [TestMethod]
        [Ignore]
        public void TestMethod2()
        {
            Console.WriteLine("Test Method two");
        }
        [TestInitialize]
        public void setup()
        {
            Console.WriteLine("Setup");
        }
        [TestCleanup]
        public void TearDown()
        {
            Console.WriteLine("CleanUp");
        }

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            Console.WriteLine("Class set up");
        }
        [ClassCleanup]
        public void ClassTearDown()
        {
            Console.WriteLine("Class tear down");
        }
        [AssemblyInitialize]
        public static void AssemblySetup(TestContext testContext)
        {
            Console.WriteLine("Assembly setup");

        }
        [AssemblyCleanup]
        public static void AssemblyTearDown()
        {

        }
    }

}
