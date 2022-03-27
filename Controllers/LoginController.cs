using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VotingWebApp2._0.Models;
using VotingWebApp2._0.Services.Business;

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
            // return "Result: Username = " + userLogin.email + " Password = "+ userLogin.password;
            
            //Checks if the user exists using authenticate method.
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userLogin);

            if (success)
            {
                return "Success";
            }
            else
            {
                return "Try again";
            }
        }
    }
}