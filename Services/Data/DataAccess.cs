using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VotingWebApp2._0.Models;

namespace VotingWebApp2._0.Services.Data
{
    public class DataAccess
    {
        //Connection to the databse 
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VotingHubDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal bool FindByUser(UserLogin user)
        {
            //start by assuming that user is not found.
            bool success = false;

            //Sql Expression
            string queryStrung = "Select * From dbo.Users WHERE username = @email and password = @password"; 

            // Seperated to protect against SQL Injection Attacks
            //create and open the connection to the database inside a using block which will close the connection. 
            //Ensuring all the the resouces are closed properly to protect against data leaks.
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryStrung, connection);
                
                //Associating the @ values defined int the query string to the UserLogin
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 150).Value = user.email;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 100).Value = user.password;

                //Open the database and run the command
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                    //connection.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);   
                }

            }
            return success;

        }
    }
}