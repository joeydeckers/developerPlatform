using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using DAL;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ApplicationDALTests
    {
        private string connectionString = "Server=php.meelsnet.nl;Uid=jdeckers;Database=jdeckers;Pwd=Hoi123;";

        [TestMethod]
        public void ReadAllApplicationsMustSucceed()
        {
            //arrange
            ApplicationDatabaseHandler testHandler = new ApplicationDatabaseHandler(connectionString);
            List<ApplicationDto> allApplications = new List<ApplicationDto>();

            //act
            allApplications = testHandler.GetAllApplications();

            //assert
            Assert.IsNotNull(allApplications);
        }

        [TestMethod]
        public void ReadApplicationMustSucceed()
        {
            //arrange
            ApplicationDatabaseHandler testHandler = new ApplicationDatabaseHandler(connectionString);
            ApplicationDto applicationDto = new ApplicationDto();

            //act
            applicationDto = testHandler.GetApplication(1);

            //assert
            Assert.IsNotNull(applicationDto);
        }

        [TestMethod]
        public void ReadApplicationMustFail()
        {
            //arrange
            ApplicationDatabaseHandler testHandler = new ApplicationDatabaseHandler(connectionString);
            ApplicationDto applicationDto = new ApplicationDto();

            //act
            applicationDto = testHandler.GetApplication(17897955);

            //assert
            Assert.AreEqual(0, applicationDto.IdApplication);
        }

        [TestMethod]
        public void CreateApplicationMustSucceed()
        {
            //arrange
            ApplicationDatabaseHandler testHandler = new ApplicationDatabaseHandler(connectionString);
            ApplicationDto applicationDto = new ApplicationDto();
            List<ApplicationDto> allApplications = new List<ApplicationDto>();
            testHandler.CreateApplication(1, 11, "hallo test");
            allApplications = testHandler.GetAllApplications();

            //act
            ApplicationDto applicationDtoToTest = allApplications.Find(x => x.ApplicationText.Contains("hallo test"));

            //assert
            Assert.AreEqual("hallo test", applicationDtoToTest.ApplicationText);
        }
    }
}
