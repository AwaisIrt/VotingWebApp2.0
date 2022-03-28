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
            return View("Details", user);
        }
        public ActionResult CreateUser()
        {
            return View("UserForm");
        }
        public ActionResult EditUser(int id)
        {
            DataAccess userDA = new DataAccess();
            UserModel user = userDA.FetchOneUser(id);
            return View("UserDetails", user);
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

    }
}