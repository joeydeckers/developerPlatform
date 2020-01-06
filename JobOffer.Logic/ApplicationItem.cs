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
    public class ApplicationItem:IApplicationItem
    {
        private IConfiguration configFile;
        private ApplicationDatabaseHandler handler;
        public ApplicationItem(IConfiguration config)
        {
            configFile = config;
            handler = new ApplicationDatabaseHandler(configFile);

        }


        public ApplicationDto GetApplication(int id)
        {

            ApplicationDto applicationDto = handler.GetApplication(id);

            ApplicationDto application = new ApplicationDto();

            application.IdApplication = applicationDto.IdApplication;
            application.UserId = applicationDto.UserId;
            application.JobofferId = applicationDto.JobofferId;
            application.ApplicationText = applicationDto.ApplicationText;

            return application;
        }
    }
}
