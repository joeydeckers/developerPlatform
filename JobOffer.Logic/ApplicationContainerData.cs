using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using Interfaces;
using Microsoft.Extensions.Configuration;


namespace Business
{
    public class ApplicationContainerData: IApplicationContainerData
    {
        private IConfiguration config;

        public ApplicationContainerData(IConfiguration config)
        {
            config = config;
        }

        public List<ApplicationDto> GetAllApplications()
        {
            List<ApplicationDto> allApplications = new List<ApplicationDto>();
            ApplicationDatabaseHandler handler = new ApplicationDatabaseHandler(config);

            List<ApplicationDto> applicationsFromDatabase = handler.GetAllApplications();

            foreach (ApplicationDto applicationDto in applicationsFromDatabase)
            {
                ApplicationDto application = new ApplicationDto();
                application.IdApplication = applicationDto.IdApplication;
                application.UserId = applicationDto.UserId;
                application.JobofferId = applicationDto.JobofferId;
                application.ApplicationText = applicationDto.ApplicationText;

                allApplications.Add(application);
            }
            return allApplications;
        }
    }
}
