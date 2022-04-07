using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCUnitTestingDemo.Tests.Controllers;
using NUnit;
using NUnit.Framework;

namespace VotingWebApp2._0.Controllers
{
    public class AdminControllerTest : Controller
    {
        public class AdminController : Controller
        {
            public ActionResult Index()
            {
                return View("Index");
            }
        }
    }
    namespace StoreTests.Controllers
    {
        [TestClass]
        public class ControllerTest
        {
            [TestMethod]
            public void TestDetailsView()
            {
                var controller = new AdminController();
                var result = controller.Index(2) as ViewResult;
                Assert.AreEqual("Details", result.ViewName);

            }
        }
    }
}