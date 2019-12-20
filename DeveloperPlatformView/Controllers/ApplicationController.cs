using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business;
using Models;
using DeveloperPlatformView.Models;


namespace DeveloperPlatformView.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            List<ApplicationDto> allAplications = new List<ApplicationDto>();

            List<ApplicationModel> allApplicationModels = new List<ApplicationModel>();

            ApplicationContainerData applications = new ApplicationContainerData();

            allAplications = applications.GetAllApplications();


            foreach (var application in allAplications)
            {
                ApplicationModel viewModel = new ApplicationModel()
                {
                    IdApplication = application.JobofferId,
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

            ApplicationItem applcation = new ApplicationItem();

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
    }
}