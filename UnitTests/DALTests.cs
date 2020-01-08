using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;
using DAL;
using Microsoft.Extensions.Configuration;

namespace UnitTests
{
    [TestClass]
    public class DALTests
    {
        [TestMethod]
        public void ReadJobOffersMustSucceed()
        {
            //arrange
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler("temp");
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
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler("temp");
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
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler("temp");
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
            JobOfferDatabaseHandler testHandler = new JobOfferDatabaseHandler("temp");
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();

            //act
            testHandler.AddJobOffer("test", "test", 1, 1, 1, "Fulltime");
            allJobOffers = testHandler.GetJoboffers();

            int jobOffers = allJobOffers.Count;

            //assert
            Assert.AreNotEqual(0, jobOffers);
        }
    }
}
