using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IJobOfferItem
    {
        JobOfferDto GetJobOffer(int id);
        void CreateJobOffer(string name, string description, int companyid, int catId, int applicationId, string jobType);
        void UpdateJobOffer(string name, string description, int companyid, int catId, int applicationId, string jobType);
        void DeleteJobOffer(int companyId, int jobOfferId);
    }
}
