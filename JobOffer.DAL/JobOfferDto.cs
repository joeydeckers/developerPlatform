using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobOffer.DAL;

namespace JobOffer.DAL
{
    public class JobOfferDto
    {
        public int idJoboffer { get; internal set; }
        public string name { get; internal set; }
        public string description { get; internal set; }
        public int companyId { get; internal set; }
        public int catId { get; internal set; }
        public int applicationId { get; internal set; }
        public string jobType { get; internal set; }
    }
}
