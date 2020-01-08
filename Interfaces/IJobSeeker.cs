using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IJobSeeker
    {
        string Name { get; set; }
        string Email { get; set; }

        void CreateJobOffer(int userId, int jobOfferId, string applicationText);
    }
}
