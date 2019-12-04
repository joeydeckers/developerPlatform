using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeveloperPlatformView.Models;
//using System.Web;
using JobOffer.Business;
namespace DeveloperPlatformView.Controllers
{
    public class JobOfferController : Controller
    {
       // private List<JobOfferContainer> jobOffers;

        public IActionResult Index()
        {
            List<JobOfferContainer> allJobOffers = new List<JobOfferContainer>();

            List<JobOfferModel> allJobOfferModels = new List<JobOfferModel>();

            allJobOffers = JobOfferContainer.GetAllJobOffers();


            foreach (var jobOffer in allJobOffers)
            {
                JobOfferModel viewModel = new JobOfferModel()
                {
                    Name = jobOffer._name,
                    JobType = jobOffer._jobType
                };
                allJobOfferModels.Add(viewModel);
            }

            return View(allJobOfferModels);

        }


    }
}