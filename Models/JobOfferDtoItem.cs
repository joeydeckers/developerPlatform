using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobOfferDtoItem
    {
        public int IdJoboffer { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public int CompanyId { get;  set; }
        public int CatId { get;  set; }
        public int ApplicationId { get;  set; }
        public string JobType { get; set; }
    }
}
