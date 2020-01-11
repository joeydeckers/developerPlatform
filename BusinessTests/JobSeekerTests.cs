using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using DAL;
using Business;
using System.Collections.Generic;

namespace BusinessTests
{
    [TestClass]
    public class JobSeekerTests
    {
        private string connectionString = "Server=php.meelsnet.nl;Uid=jdeckers;Database=jdeckers;Pwd=Hoi123;";

        [TestMethod]
        public void ApplyToJobOfferTestResultToSucceed()
        {
            //arrange
            JobSeeker jobSeekerTest = new JobSeeker(connectionString);
            ApplicationDatabaseHandler applicationDatabase = new ApplicationDatabaseHandler(connectionString);
            List<ApplicationDto> allApplications = new List<ApplicationDto>();


            //act
            jobSeekerTest.ApplyToJobOffer(1, 1, "Test voor intergrationTest 12345");
            allApplications = applicationDatabase.GetAllApplications();
            ApplicationDto applicationToTest = allApplications.Find(x => x.ApplicationText.Contains("Test voor intergrationTest 12345"));
            //assert

            Assert.AreEqual("Test voor intergrationTest 12345", applicationToTest.ApplicationText);
        }
    }
}
