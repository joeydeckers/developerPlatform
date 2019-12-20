using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using Interfaces;

namespace Business
{
    public class ApplicationItem:IApplicationItem
    {
        ApplicationDatabaseHandler handler = new ApplicationDatabaseHandler();

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

        //public void DeleteJobOffer(int companyId, int jobOfferId)
        //{
        //    handler.DeleteJobOffer(companyId, jobOfferId);
        //}
    }
}
