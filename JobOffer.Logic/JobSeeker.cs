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
        private IConfiguration configFile;
        private ApplicationDatabaseHandler handler;
        private string ConnectionString;

        public JobSeeker(string givenString)
        {
            ConnectionString = givenString;
            handler = new ApplicationDatabaseHandler(ConnectionString);
        }


        public void CreateJobOffer(int userId, int jobOfferId, string applicationText)
        {
            handler.CreateApplication(userId, jobOfferId, applicationText);
        }
    }
}
