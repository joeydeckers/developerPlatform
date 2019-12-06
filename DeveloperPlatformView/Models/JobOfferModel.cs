using System;
using System.ComponentModel.DataAnnotations;

namespace DeveloperPlatformView.Models
{
    public class JobOfferModel
    {
        public int JobOfferId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public int CatId { get; set; }
        public int ApplicationId { get; set; }
        public string JobType { get; set; }
    }
}