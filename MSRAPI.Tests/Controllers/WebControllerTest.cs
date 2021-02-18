using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MSRAPI.Controllers; // define controller name 

namespace MSRAPI.Tests.Controllers
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class WebControllerTest //Give controller Test name
    {
        [TestMethod]
        public void GetWebData() //write method whose given in particulour controller 
        {
            WebController web = new WebController(); //
            var result = web.GetWebData(12, 2020);

        }
        [TestMethod]
        public void GetYearAndMonth()
        {
            WebController web = new WebController();
            var result = web.GetYearAndMonths();

        }
        [TestMethod]
        public void GetHelpDeskTickets()
        {
            WebController web = new WebController();

            var result = web.GetHelpDeskTickets(2,2021);

            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void GetWebTrendReportData()
        {
            WebController web = new WebController();
            var result = web.GetWebTrendReportData(2, 2021);

            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void GetWebPrivateData()
        {
            WebController web = new WebController();
            var result = web.GetWebPrivateData(2, 2021);

            //
            // TODO: Add constructor logic here
            //
        }

        public WebControllerTest()
        {

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    //
        //    // TODO: Add test logic here
        //    //
        //}
    }
}
