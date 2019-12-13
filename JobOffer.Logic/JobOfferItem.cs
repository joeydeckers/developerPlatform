using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobOffer.DAL;

namespace JobOffer.Business
{
    public class JobOfferItem
    {
        public int IdJoboffer { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public int CompanyId { get; internal set; }
        public int CatId { get; internal set; }
        public int ApplicationId { get; internal set; }
        public string JobType { get; internal set; }

        JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler();

        //public JobOfferItem(int idJoboffer, string name, string description, int companyId, int catId, int applicationId, string jobType)
        //{
        //    IdJoboffer = idJoboffer;
        //    Name = name;
        //    Description = description;
        //    CompanyId = companyId;
        //    CatId = catId;
        //    ApplicationId = applicationId;
        //    JobType = jobType;
        //}

        public JobOfferItem GetJobOffer(int id)
        {
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler();

            JobOfferDto jobOfferDto = handler.GetJoboffer(id);

            // JobOfferItem jobOffer = new JobOfferItem(jobOfferDto.IdJoboffer, jobOfferDto.Name, jobOfferDto.Description, jobOfferDto.CompanyId, jobOfferDto.CatId, jobOfferDto.ApplicationId, jobOfferDto.JobType);

            JobOfferItem jobOffer = new JobOfferItem();
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
