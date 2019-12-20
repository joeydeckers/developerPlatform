using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Interfaces;

namespace Business
{
    public class JobOfferItem : IJobOfferItem
    {

        JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler();

        public JobOfferDto GetJobOffer(int id)
        {
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler();

            JobOfferDto jobOfferDto = handler.GetJoboffer(id);

            JobOfferDto jobOffer = new JobOfferDto();

            jobOffer.IdJoboffer = jobOfferDto.IdJoboffer;
            jobOffer.Name = jobOfferDto.Name;
            jobOffer.Description = jobOfferDto.Description;
            jobOffer.CompanyId = jobOfferDto.CompanyId;
            jobOffer.CatId = jobOfferDto.CatId;
            jobOffer.ApplicationId = jobOfferDto.ApplicationId;
            jobOffer.JobType = jobOfferDto.JobType;

            return jobOffer;
        }
        public void CreateJobOffer(string name, string description, int companyid, int catId, int applicationId, string jobType)
        {
            handler.AddJobOffer(name, description, companyid, catId, applicationId, jobType);
        }

        public void UpdateJobOffer(string name, string description, int companyid, int catId, int applicationId, string jobType)
        {
            handler.UpdateJobOffer(name, description, companyid, catId, applicationId, jobType);
        }

        public void DeleteJobOffer(int companyId, int jobOfferId)
        {
            handler.DeleteJobOffer(companyId, jobOfferId);
        }
    }
}
