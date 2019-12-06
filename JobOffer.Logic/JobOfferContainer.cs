using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobOffer.DAL;
using Interfaces;

namespace JobOffer.Business
{
    public class JobOfferContainer
    {
        public static List<JobOfferItem> GetAllJobOffers()
        {
            List<JobOfferItem> allJobOffers = new List<JobOfferItem>();
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler();

            var jobOffersFromDatabse = handler.GetJoboffers();

            foreach (var jobOfferDto in jobOffersFromDatabse)
            {
                //JobOfferItem jobOffer = new JobOfferItem(jobOfferDto.IdJoboffer, jobOfferDto.Name, jobOfferDto.Description, jobOfferDto.CompanyId, jobOfferDto.CatId, jobOfferDto.ApplicationId, jobOfferDto.JobType);
                JobOfferItem jobOffer = new JobOfferItem();
                jobOffer.IdJoboffer = jobOfferDto.IdJoboffer;
                jobOffer.Name = jobOfferDto.Name;
                jobOffer.Description = jobOfferDto.Description;
                jobOffer.CompanyId = jobOfferDto.CompanyId;
                jobOffer.CatId = jobOfferDto.CatId;
                jobOffer.ApplicationId = jobOfferDto.ApplicationId;
                jobOffer.JobType = jobOfferDto.JobType;


                allJobOffers.Add(jobOffer);
            }
           handler.AddJobOffer("GoLang Developer Gezocht", "test", 1, 1, 1, "Fulltime");
            return allJobOffers;
        }

    }
}
