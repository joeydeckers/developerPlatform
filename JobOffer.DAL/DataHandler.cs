using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DataHandler {


        public string connectionString { get; private set; }

        public DataHandler(IConfiguration config)
        {
            //Try to get the config if not catch to default
            try
            {
                connectionString = config.GetSection("ConnectionStrings")["database"];
            }
            catch
            {
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JoeyD\Desktop\developerPlatform\JobOffer.DAL\Database1.mdf;Integrated Security=True";
            }

        }

        //public readonly string connectionString = WebConfigurationManager.ConnectionStrings["JobOffer.DAL.Properties.Settings.Database1ConnectionString"].ConnectionString;

        //public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JoeyD\Desktop\developerPlatform\JobOffer.DAL\Database1.mdf;Integrated Security=True";
        // voor laptop
        //private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Joey Deckers\Documents\developerPlatform\JobOffer.DAL\Database1.mdf;Integrated Security=True";

    }
}
