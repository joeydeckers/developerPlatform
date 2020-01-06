using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace UnitTests
{
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void GetAllApplicationsMustSucceed()
        {
            //arrange
            ApplicationContainerData applicationContainer = new ApplicationContainerData(IConfiguration config);
            List<ApplicationDto> allApplications = new List<ApplicationDto>();

            //act
            applicationContainer.GetAllApplications();

            //assert

            Assert.IsNotNull(allApplications);
        }

        public void GetApplicationMustSucceed()
        {
            //arrange
            ApplicationItem application = new ApplicationItem();
            ApplicationDto applicationDto = new ApplicationDto();

            //act
            applicationDto = application.GetApplication(1);

            //assert

            Assert.IsNotNull(application);
        }
    }
}
