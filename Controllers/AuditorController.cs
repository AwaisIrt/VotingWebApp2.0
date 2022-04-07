using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VotingWebApp2._0.Models;
using VotingWebApp2._0.Services.Data;

namespace VotingWebApp2._0.Controllers
{
    public class AuditorController : Controller
    {
        // GET: Auditor
        public ActionResult Audit()
        {
            //List of the user model
            List<VoteModel> votes = new List<VoteModel>();
            //Instance of the database where it gets the list. 
            DataAccess voteDA = new DataAccess();

            votes = voteDA.FetchAllVotes();

            return View("Audit", votes);
        }
    }
}