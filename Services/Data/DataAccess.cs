using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VotingWebApp2._0.Models;

namespace VotingWebApp2._0.Services.Data
{
    public class DataAccess
    {
        internal bool FindByUser(UserLogin user)
        {
            //throw new NotImplementedException();
            //if(user.email == "Admin" && user.password == "Password")
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return (user.email == "Admin" && user.password == "Password");
        }
    }
}