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
        public int IdJoboffer { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public int CompanyId { get; internal set; }
        public int CatId { get; internal set; }
        public int ApplicationId { get; internal set; }
        public string JobType { get; internal set; }
    }
}
