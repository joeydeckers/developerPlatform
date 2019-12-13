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
            List<JobOfferItem> allJobOffers = new List<JobOfferItem>();

            List<JobOfferModel> allJobOfferModels = new List<JobOfferModel>();

            allJobOffers = JobOfferContainer.GetAllJobOffers();


            foreach (var jobOffer in allJobOffers)
            {
                JobOfferModel viewModel = new JobOfferModel()
                {
                    JobOfferId = jobOffer.IdJoboffer,
                    Name = jobOffer.Name,
                    JobType = jobOffer.JobType
                };
                allJobOfferModels.Add(viewModel);
            }

            return View(allJobOfferModels);

        }
        public IActionResult ShowJobOffer(int id) {

            JobOfferItem jobOffer = new JobOfferItem();

            jobOffer = jobOffer.GetJobOffer(id);

            JobOfferModel viewModel = new JobOfferModel()
            {
                JobOfferId = jobOffer.IdJoboffer,
                Name = jobOffer.Name,
                Description = jobOffer.Description,
                JobType = jobOffer.JobType
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateJobOffer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateJobOffer(JobOfferModel jobOfferModel)
        {

            if (ModelState.IsValid == false)
            {
                return View(jobOfferModel);
            }
            else
            {
                JobOfferItem jobOffer = new JobOfferItem();
                jobOffer.CreateJobOffer(jobOfferModel.Name, jobOfferModel.Description, 1, 1,1, "fulltime");

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult UpdateJobOffer(int id)
        {
            JobOfferItem jobOffer = new JobOfferItem();

            jobOffer = jobOffer.GetJobOffer(id);

            JobOfferModel viewModel = new JobOfferModel()
            {
                JobOfferId = jobOffer.IdJoboffer,
                Name = jobOffer.Name,
                Description = jobOffer.Description,
                JobType = jobOffer.JobType
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdateJobOffer(JobOfferModel jobOfferModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(jobOfferModel);
            }
            else
            {
                JobOfferItem jobOffer = new JobOfferItem();
                jobOffer.CreateJobOffer(jobOfferModel.Name, jobOfferModel.Description, 1, 1, 1, "fulltime");

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult DeleteJobOffer(JobOfferModel jobOfferModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(jobOfferModel);
            }
            else
            {
                JobOfferItem jobOffer = new JobOfferItem();
                jobOffer.CreateJobOffer(jobOfferModel.Name, jobOfferModel.Description, 1, 1, 1, "fulltime");

                return RedirectToAction("Index");
            }
        }
    }
}