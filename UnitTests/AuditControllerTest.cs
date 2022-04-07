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
    public class AuditControllerTest
    {
         [TestMethod]
        public void TestAuditView()
        {
            //Arranges the input controller
            AuditorController controller = new AuditorController();

            //returns the view 
            ViewResult result = controller.Audit() as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
    }
}