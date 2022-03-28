using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VotingWebApp2._0.Models;
using VotingWebApp2._0.Services.Data;

namespace VotingWebApp2._0.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            //List of the user model
            List<UserModel> users = new List<UserModel>();
            //Instance of the database where it gets the list. 
            DataAccess userDA = new DataAccess();

            users = userDA.FetchAllUsers();
            
            return View("Index", users);
        }
        public ActionResult UserDetails(int id)
        {
            
            DataAccess userDA = new DataAccess();
            UserModel user = userDA.FetchOneUser(id);
            return View("UserDetails", user);
        }
        public ActionResult CreateUser()
        {
            return View("UserForm", new UserModel());
        }
        public ActionResult EditUser(int id)
        {
            DataAccess userDA = new DataAccess();
            UserModel user = userDA.FetchOneUser(id);
            return View("UserForm", user);
        }
        public ActionResult DeleteUser(int id)
        {
            DataAccess userDA = new DataAccess();
            userDA.DeleteUser(id);
            List<UserModel> users = userDA.FetchAllUsers();
            return View("Index", users);
        }
        public ActionResult ProcessCreateUser(UserModel userModel)
        {
            DataAccess userDA = new DataAccess();
            int newID = userDA .CreateUser(userModel);
            return View("UserDetails", userModel);
        }

        public ActionResult AllCandidate()
        {
            //List of the user model
            List<CandidateModel> cands = new List<CandidateModel>();
            //Instance of the database where it gets the list. 
            DataAccess candsDA = new DataAccess();

            cands = candsDA.FetchAllCandidates();

            return View("AllCandidate", cands);
        }
        public ActionResult AllCampaigns()
        {
            //List of the user model
            List<CampaignModel> camps = new List<CampaignModel>();
            //Instance of the database where it gets the list. 
            DataAccess campaignDA = new DataAccess();

            camps = campaignDA.FetchAllCampaigns();

            return View("AllCampaigns", camps);
        }

        public ActionResult CreateCampaign()
        {
            return View("CreateCampaign");
        }
        public ActionResult ProcessCreateCampaign(CampaignModel campModel)
        {
            DataAccess campaignDA = new DataAccess();
            int newID = campaignDA.CreateCampaign(campModel);
            return View("CreateCampaign", campModel);
        }
        public ActionResult CreateCandidate()
        {
            return View("CreateCandidate");
        }
        public ActionResult ProcessCreateCandidate(CandidateModel candModel)
        {
            DataAccess candidateDA = new DataAccess();
            int newID = candidateDA.CreateCandidate(candModel);
            return View("CreateCandidate", candModel);
        }
        public ActionResult EditCandidate(int id)
        {
            DataAccess candDA = new DataAccess();
            CandidateModel candidate = candDA.FetchOneCandidate(id);
            return View("CreateCandidate", candidate);
        }
        public ActionResult EditCampaign(int id)
        {
            DataAccess campDA = new DataAccess();
            CampaignModel campaign = campDA.FetchOneCampaign(id);
            return View("CreateCampaign", campaign);
        }

        public ActionResult CampaignDetails(int id)
        {

            DataAccess campDA = new DataAccess();
            CampaignModel campModel = campDA.FetchOneCampaign(id);
            return View("CampaignDetails", campModel );
        }
        public ActionResult CandidateDetails(int id)
        {

            DataAccess candDA = new DataAccess();
            CampaignModel candidate = candDA.FetchOneCampaign(id);
            return View("CampaignDetails", candDA);
        }

        public ActionResult DeleteCandidate(int id)
        {
            DataAccess candDA = new DataAccess();
            candDA.DeleteCandidate(id);
            List<CandidateModel> candidate = candDA.FetchAllCandidates();
            return View("AllCandidate", candidate);
        }
        public ActionResult DeleteCampaign(int id)
        {
            DataAccess campDA = new DataAccess();
            campDA.DeleteCandidate(id);
            List<CampaignModel> campaign = campDA.FetchAllCampaigns();
            return View("AllCampaign", campaign);
        }

    }
}