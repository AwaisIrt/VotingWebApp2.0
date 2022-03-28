using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingWebApp2._0.Models
{
    public class CampaignModel
    {
        public int campaignId { get; set; }
        public string campaignName { get; set; }
        public string campaignDescription { get; set; }
        public string statusOFCampaign { get; set; }

        public CampaignModel()
        {
            campaignId = -1;
            campaignName = string.Empty;
            campaignDescription = string.Empty; 
            statusOFCampaign = string.Empty;
        }

        public CampaignModel(int campaignId, string campaignName, string campaignDescription, string statusOFCampaign)
        {
            this.campaignId = campaignId;
            this.campaignName = campaignName;
            this.campaignDescription = campaignDescription;
            this.statusOFCampaign = statusOFCampaign;
        }
    }
}