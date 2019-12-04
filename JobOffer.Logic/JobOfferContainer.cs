using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobOffer.DAL;
using Interfaces;

namespace JobOffer.Business
{
    public class JobOfferContainer: IJobOfferContainerData
    {
        public int _idJoboffer { get; internal set; }
        public string _name { get; internal set; }
        public string _description { get; internal set; }
        public int _companyId { get; internal set; }
        public int _catId { get; internal set; }
        public int _applicationId { get; internal set; }
        public string _jobType { get; internal set; }


        public JobOfferContainer(int idJoboffer, string name, string description, int companyId, int catId, int applicationId, string jobType)
        {
            _idJoboffer = idJoboffer;
            _name = name;
            _description = description;
            _companyId = companyId;
            _catId = catId;
            _applicationId = applicationId;
            _jobType = jobType;
        }

        public static List<JobOfferContainer> GetAllJobOffers()
        {
            List<JobOfferContainer> allJobOffers = new List<JobOfferContainer>();
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler();

            var jobOffersFromDatabse = handler.GetJoboffers();

            foreach (var jobOfferDto in jobOffersFromDatabse)
            {
                JobOfferContainer jobOffer = new JobOfferContainer(jobOfferDto.idJoboffer, jobOfferDto.name, jobOfferDto.description, jobOfferDto.companyId, jobOfferDto.catId, jobOfferDto.applicationId, jobOfferDto.jobType);
                allJobOffers.Add(jobOffer);
            }

            return allJobOffers;
        }

        public override string ToString()
        {
            return _name;
        }
    }


}
