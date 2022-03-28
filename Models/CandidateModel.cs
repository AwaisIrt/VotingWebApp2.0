using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingWebApp2._0.Models
{
    public class CandidateModel
    {
        public int candidateID { get; set; }
        public string candidateName { get; set; }
        public string campaign { get; set; }

        public CandidateModel()
        {
            candidateID = 0;    
            candidateName = string.Empty;
            campaign = string.Empty;    
        }

        public CandidateModel(int candidateID, string candidateName, string campaign)
        {
            this.candidateID = candidateID;
            this.candidateName = candidateName;
            this.campaign = campaign;
        }
    }
}