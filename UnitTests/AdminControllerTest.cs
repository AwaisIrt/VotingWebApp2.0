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
    public class AdminControllerTest
    {

        [TestMethod]
        public void TestIndexView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.Index() as ViewResult;

            //ensures view is returned. 
            Assert.AreEqual("Index", result.ViewName);
        }
       
        [TestMethod]
        public void TestUserDetailsView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.UserDetails(1000) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestCreateUserView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.CreateUser() as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestEditUserView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.EditUser(1000) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteUserView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.DeleteUser(1000) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestProcessCreateUserView(UserModel userModel)
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.ProcessCreateUser(userModel) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestAllCandidateView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.AllCandidate() as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestAllCampaignsView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.AllCampaigns() as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestCreateCampaignView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.CreateCampaign() as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestProcessCreateCampaignView(CampaignModel campModel)
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.ProcessCreateCampaign(campModel) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestCreateCandidateView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.CreateCandidate() as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestProcessCreateCandidateView(CandidateModel candModel)
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.ProcessCreateCandidate(candModel) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestEditCandidateView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.EditCandidate(1000) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestEditCampaignView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.EditCampaign(1) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestCampaignDetailsView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.CampaignDetails(1) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestCandidateDetailsView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.CandidateDetails(1) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteCandidateView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.DeleteCandidate(1) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteCampaignView()
        {
            //Arranges the input controller
            AdminController controller = new AdminController();

            //returns the view 
            ViewResult result = controller.DeleteCampaign(1) as ViewResult;

            //ensures view is returned. 
            Assert.IsNotNull(result);
        }
    }
}