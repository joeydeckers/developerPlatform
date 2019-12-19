using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class ApplicationDatabaseHandler:DataHandler
    {
       // private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JoeyD\Documents\developerPlatform\DAL\Database1.mdf;Integrated Security=True";
        //private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Joey Deckers\Documents\developerPlatform\JobOffer.DAL\Database1.mdf;Integrated Security=True";
        public List<ApplicationDto> GetAllApplications()
        {
            List<ApplicationDto> allApplications = new List<ApplicationDto>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "select * from Applications";
                    //string query = "select * from JobOffers";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ApplicationDto dto = new ApplicationDto();
                            dto.IdApplication = reader.GetInt32(0);
                            dto.UserId = reader.GetInt32(1);
                            dto.JobofferId = reader.GetInt32(2);
                            dto.ApplicationText = reader.GetString(3);

                            allApplications.Add(dto);
                        }
                    }
                }
            }
            catch (SqlException exp)
            {
               
            }
            return allApplications;

        }
    }
}
