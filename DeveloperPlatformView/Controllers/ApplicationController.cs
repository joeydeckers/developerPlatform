using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using Models;
using DeveloperPlatformView.Models;
using Microsoft.Extensions.Configuration;

namespace DeveloperPlatformView.Controllers
{
    public class ApplicationController : Controller
    {
        private IConfiguration configFile;
        public static string ConnectionString { get; private set; }

        public ApplicationController(IConfiguration config)
        {
            configFile = config;
            ConnectionString = config["ConnectionStrings:database"];
        }


        public IActionResult Index()
        {
            List<ApplicationDto> allAplications = new List<ApplicationDto>();

            List<ApplicationModel> allApplicationModels = new List<ApplicationModel>();

            ApplicationContainerData applications = new ApplicationContainerData(ConnectionString);

            allAplications = applications.GetAllApplications();


            foreach (var application in allAplications)
            {
                ApplicationModel viewModel = new ApplicationModel()
                {
                    IdApplication = application.IdApplication,
                    UserId = application.UserId,
                    JobofferId = application.JobofferId,
                    ApplicationText = application.ApplicationText
                };
                allApplicationModels.Add(viewModel);
            }

            return View(allApplicationModels);

        }

        [HttpGet]
        public IActionResult ShowApplication(int id) {

            ApplicationItem applcation = new ApplicationItem(ConnectionString);

            ApplicationDto applicationDto = new ApplicationDto();

            applicationDto = applcation.GetApplication(id);


            ApplicationModel viewModel = new ApplicationModel()
            {
                IdApplication = applicationDto.JobofferId,
                UserId = applicationDto.UserId,
                JobofferId = applicationDto.JobofferId,
                ApplicationText = applicationDto.ApplicationText
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateApplication(int id)
        {
            ApplicationItem applcation = new ApplicationItem(ConnectionString);

            ApplicationDto applicationDto = new ApplicationDto();

            applicationDto = applcation.GetApplication(id);


            ApplicationModel viewModel = new ApplicationModel()
            {
                IdApplication = applicationDto.JobofferId,
                UserId = applicationDto.UserId,
                JobofferId = applicationDto.JobofferId,
                ApplicationText = applicationDto.ApplicationText
            };

            return View(viewModel);

        }


        [HttpPost]
        public ActionResult CreateApplication(ApplicationModel applicationModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(applicationModel);
            }

            JobSeeker jobSeeker = new JobSeeker(ConnectionString);
            jobSeeker.CreateJobOffer(1, applicationModel.JobofferId, applicationModel.ApplicationText);

            return RedirectToAction("Index");

        }
    }
}