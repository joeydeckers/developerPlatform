using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicationDto
    {
        public int IdApplication { get; set; }
        public int UserId { get; set; }
        public int JobofferId { get; set; }
        public string ApplicationText { get; set; }
    }
}
