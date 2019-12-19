using System;
using System.ComponentModel.DataAnnotations;

namespace DeveloperPlatformView.Models
{
    public class ApplicationModel
    {
        public int IdApplication { get; set; }
        public int UserId { get; set; }
        public int JobofferId { get; set; }
        public string ApplicationText { get; set; }
    }
}
