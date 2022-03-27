using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VotingWebApp2._0.Models;
using VotingWebApp2._0.Services.Data;

namespace VotingWebApp2._0.Services.Business
{
    //Authenticate if a User is real or false. 
    public class SecurityService
    {
        DataAccess daoServices = new DataAccess();
        
        public bool Authenticate(UserLogin user)
        {
            return daoServices.FindByUser(user);
        }
    }
}