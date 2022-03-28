using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VotingWebApp2._0.Models;
using VotingWebApp2._0.Services.Business;
using VotingWebApp2._0.Services.Data;

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
               
                if (userLogin.usertype == "Admin" || userLogin.usertype == "admin")
                {
                   return RedirectToAction("Index", "Admin");
                }
                else
                {
                    if (userLogin.usertype == "Voter" || userLogin.usertype == "voter" || userLogin.usertype == null)
                    {
                        //return UserType = "Voter";
                    }
                    else if ((userLogin.usertype == "Auditor" || userLogin.usertype == "auditor"))
                    {
                        return RedirectToAction("Audit", "Auditor");
                    }
                }
            }
            else
            {
                //Return the login failure if incorrect details added. 
                return View("LoginFailure");

            }
            return View();
        }
        public ActionResult Registration()
        {
            ViewBag.Message = "User Registration";
            return View();
        }
        
        
    }
}