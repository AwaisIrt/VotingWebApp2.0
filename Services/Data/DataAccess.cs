using System;
using System.Collections.Generic;
using System.Data;
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
                    queryString = "UPDATE dbo.Users set email = @email, password =@password, firstName = @firstName, lastName = @lastName, userType = @userType where Id = @Id";
                }
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = userModel.userID;
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
        //Delete
        public int DeleteUser(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "DELETE FROM dbo.Users where id = @Id";




                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                int deltedID = command.ExecuteNonQuery();

                connection.Close();

                return deltedID;


            }
        }

        public List<CandidateModel> FetchAllCandidates()
        {
            List<CandidateModel> returnList = new List<CandidateModel>();
            string queryString = "Select * From dbo.Candidate";



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
                        CandidateModel Candidate = new CandidateModel();
                        Candidate.candidateID = reader.GetInt32(0);
                        Candidate.candidateName = reader.GetString(1);
                        Candidate.campaign = reader.GetString(2);


                        returnList.Add(Candidate);
                    }
                }

                reader.Close();
                //connection.Close();




                return returnList;
            }
        }
        public List<CampaignModel> FetchAllCampaigns()
        {
            List<CampaignModel> returnList = new List<CampaignModel>();
            string queryString = "Select * From dbo.Campaign";



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
                        CampaignModel Campaign = new CampaignModel();
                        Campaign.campaignId = reader.GetInt32(0);
                        Campaign.campaignName = reader.GetString(1);
                        Campaign.campaignDescription = reader.GetString(2);
                        Campaign.statusOFCampaign = reader.GetString(2);

                        returnList.Add(Campaign);
                    }
                }

                reader.Close();
                //connection.Close();




                return returnList;
            }
        }
        public int CreateCampaign(CampaignModel campModel)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "";
                if (campModel.campaignId <= 0)
                {
                    queryString = "INSERT INTO dbo.Campaign VALUES (@campaignName, @statusofCampaign, @campaignDescription)";
                }
                else
                {
                    queryString = "UPDATE dbo.Campaign set campaignName = @campaignName, statusofCampaign =@statusofCampaign, campaignDescription = @campaignDescription where campaignID = @Id";
                }
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = campModel.campaignId;
                command.Parameters.Add("@campaignName", System.Data.SqlDbType.Text).Value = campModel.campaignName;
                command.Parameters.Add("@statusOFCampaign", System.Data.SqlDbType.Text).Value = campModel.statusOFCampaign;
                command.Parameters.Add("@campaignDescription", System.Data.SqlDbType.Text).Value = campModel.campaignDescription;
               

                connection.Open();
                int newID = command.ExecuteNonQuery();

                connection.Close();

                return newID;


            }
        }
        public int CreateCandidate(CandidateModel candModel)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "";
                if (candModel.candidateID <= 0)
                {
                    queryString = "INSERT INTO dbo.Candidate VALUES (@candidateName, @campaign)";
                }
                else
                {
                    queryString = "UPDATE dbo.Candidate set candidateName = @candidateName, campaign = @campaign where candidateID = @Id";
                }
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = candModel.candidateID;
                command.Parameters.Add("@candidateName", System.Data.SqlDbType.Text).Value = candModel.candidateName;
                command.Parameters.Add("@campaign", System.Data.SqlDbType.Text).Value = candModel.campaign;
               


                connection.Open();
                int newID = command.ExecuteNonQuery();

                connection.Close();

                return newID;


            }
        }
        public CandidateModel FetchOneCandidate(int id)
        {

            string queryString = "Select * From dbo.Candidate WHERE candidateID = @Id";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating @id with id parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                CandidateModel candidate = new CandidateModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create a new user object and add it to the list.

                        candidate.candidateID = reader.GetInt32(0);
                        candidate.candidateName = reader.GetString(1);
                        candidate.campaign = reader.GetString(2);
                        


                    }
                }

                reader.Close();

                return candidate;

            }
        }
        public CampaignModel FetchOneCampaign(int id)
        {

            string queryString = "Select * From dbo.Campaign WHERE campaignID = @Id";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating @id with id parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                CampaignModel campModel = new CampaignModel();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create a new user object and add it to the list.

                        campModel.campaignId = reader.GetInt32(0);
                        campModel.campaignName = reader.GetString(1);
                        campModel.campaignDescription = reader.GetString(2);
                        campModel.statusOFCampaign = reader.GetString(3);


                    }
                }

                reader.Close();

                return campModel;

            }
        }
        public int DeleteCandidate(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "DELETE FROM dbo.Candidate where candidateID = @Id";




                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                int deltedID = command.ExecuteNonQuery();

                connection.Close();

                return deltedID;


            }
        }
        public int DeleteCampaing(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "DELETE FROM dbo.Campaign where campaignID = @Id";




                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating parameter
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                int deltedID = command.ExecuteNonQuery();

                connection.Close();

                return deltedID;


            }
        }
        public List<VoteModel> FetchAllVotes()
        {
            List<VoteModel> returnList = new List<VoteModel>();
            string queryString = "Select * From dbo.Vote";



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
                        VoteModel vote = new VoteModel();
                        vote.voteId = reader.GetInt32(0);
                        vote.userId = reader.GetInt32(1);
                        vote.campaign = reader.GetString(2);
                        vote.Candidate = reader.GetString(3);
                      

                        returnList.Add(vote);
                    }
                }

                reader.Close();
                //connection.Close();




                return returnList;

            }
        }
        public int CreateVote(VoteModel voteModel)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO dbo.Vote VALUES (@voteId, @userId, @campaign, @candidate)";
                
                
                //Defining the command and parameter objects 
                SqlCommand command = new SqlCommand(queryString, connection);

                //Associating parameter
                command.Parameters.Add("@voteId", System.Data.SqlDbType.Int).Value = voteModel.voteId;
                command.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = voteModel.userId;
                command.Parameters.Add("@campaign", System.Data.SqlDbType.Text).Value = voteModel.campaign;
                command.Parameters.Add("@candidate", System.Data.SqlDbType.Text).Value = voteModel.Candidate;
                

                connection.Open();
                int newID = command.ExecuteNonQuery();

                connection.Close();

                return newID;


            }
        }
    }
}