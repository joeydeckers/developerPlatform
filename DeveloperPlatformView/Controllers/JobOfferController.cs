using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeveloperPlatformView.Models;
//using System.Web;
using JobOffer.Business;
using Models;
namespace DeveloperPlatformView.Controllers
{
    public class JobOfferController : Controller
    {
        // private List<JobOfferContainer> jobOffers;

        public IActionResult Index()
        {
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();

            List<JobOfferModel> allJobOfferModels = new List<JobOfferModel>();

            JobOfferContainerData jobOffers = new JobOfferContainerData();

            allJobOffers = jobOffers.GetAllJobOffers();


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

            JobOfferDto jobOfferDto = new JobOfferDto();

            jobOfferDto = jobOffer.GetJobOffer(id);

            //jobOfferDto.ApplicationId = jobOffer.ApplicationId;

            JobOfferModel viewModel = new JobOfferModel()
            {
                JobOfferId = jobOfferDto.IdJoboffer,
                Name = jobOfferDto.Name,
                Description = jobOfferDto.Description,
                JobType = jobOfferDto.JobType
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
            //JobOfferItem jobOffer = new JobOfferItem();

            //jobOffer = jobOffer.GetJobOffer(id);

            JobOfferItem jobOffer = new JobOfferItem();

            JobOfferDto jobOfferDto = new JobOfferDto();

            jobOfferDto = jobOffer.GetJobOffer(id);

            //jobOfferDto.ApplicationId = jobOffer.ApplicationId;

            JobOfferModel viewModel = new JobOfferModel()
            {
                JobOfferId = jobOfferDto.IdJoboffer,
                CompanyId = jobOfferDto.CompanyId,
                Name = jobOfferDto.Name,
                Description = jobOfferDto.Description,
                JobType = jobOfferDto.JobType
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

        //[HttpGet]
        //public IActionResult DeleteJobOffer(int id)
        //{
        //    JobOfferItem jobOffer = new JobOfferItem();

        //    jobOffer = jobOffer.GetJobOffer(id);

        //    JobOfferModel viewModel = new JobOfferModel()
        //    {
        //        JobOfferId = jobOffer.IdJoboffer,
        //        Name = jobOffer.Name,
        //        CompanyId = jobOffer.CompanyId,
        //        Description = jobOffer.Description,
        //        JobType = jobOffer.JobType
        //    };

        //    return View(viewModel);
        //}

        [HttpGet]
        public ActionResult DeleteJobOffer(int id)
        {


            JobOfferItem jobOffer = new JobOfferItem();
            
            jobOffer.DeleteJobOffer(1, id);
            //hardcoded werkt delete wel
            //jobOffer.DeleteJobOffer(1, 3008);

            return RedirectToAction("Index");
           
        }
    }
}