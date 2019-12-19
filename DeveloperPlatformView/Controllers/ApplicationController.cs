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
        public IActionResult ShowApplication() {
            return View();
        }
    }
}