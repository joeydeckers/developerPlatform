using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Models;
using DAL;
using System.Collections.Generic;

namespace BusinessTests
{
    [TestClass]
    public class ApplicationBusinessTests
    {
        private string connectionString = "Server=php.meelsnet.nl;Uid=jdeckers;Database=jdeckers;Pwd=Hoi123;";

        [TestMethod]
        public void GetAllApplicationsMustSucceed()
        {
            //arrange
            ApplicationContainerData applicationContainer = new ApplicationContainerData(connectionString);
            List<ApplicationDto> allApplications = new List<ApplicationDto>();

            //act
            applicationContainer.GetAllApplications();

            //assert

            Assert.IsNotNull(allApplications);
        }

        [TestMethod]
        public void GetApplicationMustSucceed()
        {
            //arrange
            ApplicationItem application = new ApplicationItem(connectionString);
            ApplicationDto applicationDto = new ApplicationDto();

            //act
            applicationDto = application.GetApplication(1);

            //assert

            Assert.IsNotNull(applicationDto);
        }

        [TestMethod]
        public void IntergrationGetApplicationMustSucceed()
        {
            //arrange
            ApplicationItem application = new ApplicationItem(connectionString);
            ApplicationDatabaseHandler applicationDatabase = new ApplicationDatabaseHandler(connectionString);
            List<ApplicationDto> allApplications = new List<ApplicationDto>();
            allApplications = applicationDatabase.GetAllApplications();
            //act
            ApplicationDto applicationToTest = allApplications.Find(x => x.IdApplication.Equals(1));

            //assert

            Assert.AreEqual(1, applicationToTest.IdApplication);
        }

        [TestMethod]
        public void IntergrationGetApplicationMustFail()
        {
            //arrange
            ApplicationItem application = new ApplicationItem(connectionString);
            ApplicationDatabaseHandler applicationDatabase = new ApplicationDatabaseHandler(connectionString);
            List<ApplicationDto> allApplications = new List<ApplicationDto>();
            allApplications = applicationDatabase.GetAllApplications();
            //act
            ApplicationDto applicationToTest = allApplications.Find(x => x.IdApplication.Equals(100000000));

            //assert

            Assert.IsNull(applicationToTest);
        }

        [TestMethod]
        public void GetApplicationMustFail()
        {
            //arrange
            ApplicationItem application = new ApplicationItem(connectionString);
            ApplicationDto applicationDto = new ApplicationDto();

            //act
            applicationDto = application.GetApplication(1000000);

            //assert

            Assert.AreEqual(applicationDto.UserId = 0, 0);
        }
    }
}
