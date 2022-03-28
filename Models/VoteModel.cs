using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingWebApp2._0.Models
{
    public class VoteModel
    {
        public int voteId { get; set; }
        public int userId { get; set; }
        public string campaign { get; set; }
        public string Candidate { get; set; }

        public VoteModel()
        {
            voteId = 0;
            userId = 0;
            campaign = string.Empty;
            Candidate = string.Empty;
        }

        public VoteModel(int voteId, int userId, string campaign, string candidate)
        {
            this.voteId = voteId;
            this.userId = userId;
            this.campaign = campaign;
            Candidate = candidate;
        }
    }
}