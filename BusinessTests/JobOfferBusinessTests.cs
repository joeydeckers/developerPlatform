using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using DAL;
using Models;
using System.Collections.Generic;

namespace BusinessTests
{
    [TestClass]
    public class JobOfferBusinessTests
    {
        private string connectionString = "Server=php.meelsnet.nl;Uid=jdeckers;Database=jdeckers;Pwd=Hoi123;";

        [TestMethod]
        public void GetJobOffersMustSucceed()
        {
            //arrange
            JobOfferContainerData jobOfferDataHandler = new JobOfferContainerData(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();

            //act
            allJobOffers = jobOfferDataHandler.GetAllJobOffers();

            //assert

            Assert.IsNotNull(allJobOffers);
        }

        [TestMethod]
        public void GetJobOfferMustSucceed()
        {
            //arrange
            JobOfferItem jobOfferDataHandler = new JobOfferItem(connectionString);
            JobOfferDto jobOffer = new JobOfferDto();

            //act
            jobOffer = jobOfferDataHandler.GetJobOffer(1);

            //assert

            Assert.IsNotNull(jobOffer);
        }

        [TestMethod]
        public void CreateJobOfferMustSucceed()
        {
            //arrange
            JobOfferItem jobOffer = new JobOfferItem(connectionString);
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler(connectionString);
            JobOfferContainerData jobOfferDataHandler = new JobOfferContainerData(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();
            jobOffer.CreateJobOffer("testUnit", "test", 1, 1, 100, "Fulltime");
            allJobOffers = jobOfferDataHandler.GetAllJobOffers();

            //act

            JobOfferDto jobOfferDtoToTest = allJobOffers.Find(x => x.Name.Contains("testUnit"));
            //assert

            Assert.AreEqual("testUnit", jobOfferDtoToTest.Name);
        }

        [TestMethod]
        public void DeleteJobOfferMustSucceed()
        {
            //arrange
            JobOfferItem jobOffer = new JobOfferItem(connectionString);
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler(connectionString);
            JobOfferContainerData jobOfferDataHandler = new JobOfferContainerData(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();


            //act
            allJobOffers = jobOfferDataHandler.GetAllJobOffers();
            int index = allJobOffers.Count + 1;
            jobOffer.DeleteJobOffer(1, index);

            //assert

            Assert.AreEqual(allJobOffers.Count, index-1);
        }



        [TestMethod]
        public void IntergrationGetApplicationMustSucceed()
        {
            //arrange
            JobOfferItem jobOffer = new JobOfferItem(connectionString);
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();
            allJobOffers = handler.GetJoboffers();

            //act
            JobOfferDto jobOfferToTest = allJobOffers.Find(x => x.IdJoboffer.Equals(1));

            //assert

            Assert.AreEqual(1, jobOfferToTest.IdJoboffer);
        }

        [TestMethod]
        public void IntergrationGetApplicationMustFail()
        {
            //arrange
            JobOfferItem jobOffer = new JobOfferItem(connectionString);
            JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler(connectionString);
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();
            allJobOffers = handler.GetJoboffers();

            //act
            JobOfferDto jobOfferToTest = allJobOffers.Find(x => x.IdJoboffer.Equals(1000000000000));

            //assert

            Assert.IsNull(jobOfferToTest);
        }

        //[TestMethod]
        //public void UpdateJobOfferMustSucceed()
        //{
        //    //arrange
        //    JobOfferItem jobOffer = new JobOfferItem(connectionString);
        //    JobOfferDatabaseHandler handler = new JobOfferDatabaseHandler(connectionString);
        //    List<JobOfferDto> allJobOffers = new List<JobOfferDto>();
        //    jobOffer.UpdateJobOffer("Update Test 123", "test", 1, 1, 1, "Fulltime");
        //    allJobOffers = handler.GetJoboffers();


        //    //act
        //    JobOfferDto jobOfferToTest = allJobOffers.Find(x => x.Name.Contains("Update Test 123"));

        //    //assert

        //    Assert.AreEqual("Update Test 123", jobOfferToTest.Name);
        //}
    }
}
