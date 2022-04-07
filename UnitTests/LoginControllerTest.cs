using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingWebApp2._0.Controllers;

namespace VotingWebApp2._0.UnitTests
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void TestLoginView()
        {
            //Arranges the input controller
            LoginController controller = new LoginController();

            //returns the view 
            ViewResult result = controller.Login() as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        public void TestRegistrationView()
        {
            //Arranges the input controller
            LoginController controller = new LoginController();

            //returns the view 
            ViewResult result = controller.Registration() as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
    }
}