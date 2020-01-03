using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Interfaces;
using Microsoft.Extensions.Configuration;

namespace Business
{
    public class JobOfferItem : IJobOfferItem
    {

        private IConfiguration config;
        private JobOfferDatabaseHandler handler;

        public JobOfferItem(IConfiguration config)
        {
            config = config;
            handler = new JobOfferDatabaseHandler(config);
        }


        public JobOfferDto GetJobOffer(int id)
        {
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler(config);

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
