using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VotingWebApp2._0.Models;

namespace VotingWebApp2._0.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public string Login(UserLogin userLogin)
        {
            return "Result: Username = " + userLogin.email + " Password = "+ userLogin.password;
        }
    }
}