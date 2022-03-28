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
        internal bool FindByUser(UserModel user)
        {
            //start by assuming that user is not found.
            bool success = false;

            //Sql Expression
            string queryString = "Select * From dbo.Users WHERE email = @email and password = @password";

            // Seperated to protect against SQL Injection Attacks
            //create and open the connection to the database inside a using block which will close the connection. 
            //Ensuring all the the resouces are closed properly to protect against data leaks.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

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
        public List<UserModel> FetchAllUsers()
        {
            List<UserModel> returnList = new List<UserModel>();
            string queryString = "Select * From dbo.Users";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);



                //Open the database and run the command
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create a new user object and add it to the list.
                        UserModel user = new UserModel();
                        user.userID = reader.GetInt32(0);
                        user.email = reader.GetString(1);
                        user.firstName = reader.GetString(2);
                        user.lastName = reader.GetString(3);
                        //user.password = reader.GetString(4);
                        user.usertype = reader.GetString(5);

                        returnList.Add(user);
                    }
                }

                reader.Close();
                //connection.Close();




                return returnList;

            }
        }
        public UserModel FetchOneUser(int id)
        {

            string queryString = "Select * From dbo.Users WHERE Id = @Id";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating @id with id parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                UserModel user = new UserModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create a new user object and add it to the list.

                        user.userID = reader.GetInt32(0);
                        user.email = reader.GetString(1);
                        user.firstName = reader.GetString(2);
                        user.lastName = reader.GetString(3);
                        //user.password = reader.GetString(4);
                        user.usertype = reader.GetString(5);


                    }
                }

                reader.Close();

                return user;

            }
        }

        // Create new /Edit
        public int CreateUser(UserModel userModel)
        { 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "";
                if (userModel.userID <= 0)
                {
                    queryString = "INSERT INTO dbo.Users VALUES (@email, @password, @firstName, @lastName, @userType)";
                }
                else
                {
                    queryString = "UPDATE dbo.Users set email = @email, password =@password, firstName = @firstName, lastName = @lastName, userType = @userType";
                }
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating parameter
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 150).Value = userModel.email;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 100).Value = userModel.password;
                command.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar, 200).Value = userModel.firstName;
                command.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar, 200).Value = userModel.lastName;
                command.Parameters.Add("@userType", System.Data.SqlDbType.VarChar, 100).Value = userModel.usertype;
                
                connection.Open();
                int newID = command.ExecuteNonQuery();

                connection.Close();

                return newID;
                

            }
        }
    }
}