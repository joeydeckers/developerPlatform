using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;
using DAL;
using Microsoft.Extensions.Configuration;

namespace UnitTests
{
    [TestClass]
    public class JobOfferDALTests
    {
        private string connectionString = "Server=php.meelsnet.nl;Uid=jdeckers;Database=jdeckers;Pwd=Hoi123;";
        [TestMethod]
        public void ReadJobOffersMustSucceed()
        {
            //arrange
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();

            //act
            allJobOffers = testHandler.GetJoboffers();

            //assert
            Assert.IsNotNull(allJobOffers);
        }


        [TestMethod]
        public void ReadJobOfferMustSucceed()
        {
            //arrange
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler(connectionString);
            JobOfferDto jobOffer = new JobOfferDto();

            //act
            jobOffer = testHandler.GetJoboffer(1);

            //assert
            Assert.IsNotNull(jobOffer);
        }


        [TestMethod]
        public void ReadJobOfferMustFail()
        {
            //arrange
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler(connectionString);
            JobOfferDto jobOffer = new JobOfferDto();
            JobOfferDto jobOfferWrong = new JobOfferDto();

            //act
            jobOffer = testHandler.GetJoboffer(1);
            jobOfferWrong = testHandler.GetJoboffer(99999);

            //assert
            Assert.AreNotEqual(jobOffer, jobOfferWrong);
        }

        [TestMethod]
        public void TestAddJobOfferMustSucceed()
        {
            //arrange
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();

            //act
            testHandler.AddJobOffer("test", "test", 1, 1, 1, "Fulltime");
            allJobOffers = testHandler.GetJoboffers();

            int jobOffers = allJobOffers.Count;

            //assert
            Assert.AreNotEqual(0, jobOffers);
        }

        [TestMethod]
        public void TestUpdateJobOfferMustSucceed()
        {
            //arrange
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();

            //act
            bool result = testHandler.UpdateJobOffer("TestUpdate", "test", 1, 1, 1, "Fulltime");
            allJobOffers = testHandler.GetJoboffers();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUpdateJobOfferMustFail()
        {
            //arrange
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();

            //act
            bool result = testHandler.UpdateJobOffer("TestUpdate", "test", 1, 10000000, 1, "Fulltime");
            allJobOffers = testHandler.GetJoboffers();

            //assert
            Assert.IsFalse(result);
        }

        //[TestMethod]
        //public void DeleteJobOfferMustSucceed()
        //{
        //    //arrange
        //    JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler(connectionString);
        //    List<JobOfferDto> allJobOffers = new List<JobOfferDto>();

        //    //act
        //    bool result = testHandler.DeleteJobOffer(1, 31);

        //    //assert
        //    Assert.IsTrue(result);
        //}

        [TestMethod]
        public void DeleteUpdateJobOfferMustFail()
        {
            //arrange
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();

            //act
            bool result = testHandler.DeleteJobOffer(1, 2500);

            //assert
            Assert.IsFalse(result);
        }
    }
}
