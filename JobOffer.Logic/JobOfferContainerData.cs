using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Interfaces;
using Microsoft.Extensions.Configuration;
using Models;

namespace Business
{

    public class JobOfferContainerData : IJobOfferContainerData
    {
        private IConfiguration configFile;
        private string testString;

        public JobOfferContainerData(IConfiguration config, string test)
        {
            configFile = config;
            testString = test;
        }

        public List<JobOfferDto> GetAllJobOffers()
        {
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler(configFile);

            var jobOffersFromDatabse = handler.GetJoboffers();

            foreach (JobOfferDto jobOfferDto in jobOffersFromDatabse)
            {
                JobOfferDto jobOffer = new JobOfferDto();
                jobOffer.IdJoboffer = jobOfferDto.IdJoboffer;
                jobOffer.Name = jobOfferDto.Name;
                jobOffer.Description = jobOfferDto.Description;
                jobOffer.CompanyId = jobOfferDto.CompanyId;
                jobOffer.CatId = jobOfferDto.CatId;
                jobOffer.ApplicationId = jobOfferDto.ApplicationId;
                jobOffer.JobType = jobOfferDto.JobType;


                allJobOffers.Add(jobOffer);
            }
            return allJobOffers;
        }


    }
}
