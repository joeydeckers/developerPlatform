using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobOffer.DAL;
using Models;

namespace Interfaces
{
    public interface IJobOfferContainerData
    {
       List<JobOfferDto> GetAllJobOffers();
    }
}
