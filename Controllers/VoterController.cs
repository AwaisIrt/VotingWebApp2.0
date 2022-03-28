using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VotingWebApp2._0.Controllers
{
    public class VoterController : Controller
    {
        // GET: Voter
        public ActionResult Index()
        {
            return View();
        }
    }
}