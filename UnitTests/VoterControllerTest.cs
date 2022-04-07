using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingWebApp2._0.Controllers;
using VotingWebApp2._0.Models;

namespace VotingWebApp2._0.UnitTests
{
    [TestClass]
    public class VoterControllerTest
    {
        [TestMethod]
        public void TestVoteView(VoteModel voteModel)
        {
            //Arranges the input controller
            VoterController controller = new VoterController();

            //returns the view 
            ViewResult result = controller.CreateVote(voteModel) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
    }
}