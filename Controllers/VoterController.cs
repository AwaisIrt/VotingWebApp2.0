using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VotingWebApp2._0.Models;
using VotingWebApp2._0.Services.Data;

namespace VotingWebApp2._0.Controllers
{
    public class VoterController : Controller
    {
        // GET: Voter
        
            public ActionResult CreateVote(VoteModel voteModel)
            {
                DataAccess voteDA = new DataAccess();
                int newID = voteDA.CreateVote(voteModel);
                return View("VoteDetails", voteModel);
            }
        
    }
}