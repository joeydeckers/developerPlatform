using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Interfaces;

namespace Business
{
    public class JobSeeker: User
    {
        ApplicationDatabaseHandler handler = new ApplicationDatabaseHandler();

        public void CreateJobOffer(int userId, int jobOfferId, string applicationText)
        {
            handler.CreateApplication(userId, jobOfferId, applicationText);
        }
    }
}
