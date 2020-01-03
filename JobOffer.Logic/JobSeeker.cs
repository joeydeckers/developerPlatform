using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Interfaces;
using Microsoft.Extensions.Configuration;

namespace Business
{
    public class JobSeeker: User
    {
        private IConfiguration config;
        private ApplicationDatabaseHandler handler; 

        public JobSeeker(IConfiguration config)
        {
            config = config;
            handler = new ApplicationDatabaseHandler(config);
        }


        public void CreateJobOffer(int userId, int jobOfferId, string applicationText)
        {
            handler.CreateApplication(userId, jobOfferId, applicationText);
        }
    }
}
