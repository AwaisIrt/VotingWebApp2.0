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
        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult SignIn(UserModel userLogin)
        {
            //Checks if the user exists using authenticate method.
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userLogin);

            if (success)
            {
                //Return the Login success with the what user has logged in. 
                return View("LoginSuccess", userLogin);

            }
            else
            {
                //Return the login failure if incorrect details added. 
                return View("LoginFailure");

            }
        }
        public ActionResult Registration()
        {
            ViewBag.Message = "User Registration";
            return View();
        }
        
        
    }
}