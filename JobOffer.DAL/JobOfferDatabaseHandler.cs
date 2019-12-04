using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOffer.DAL
{
    public class JobOfferDatabaseHandler
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JoeyD\Desktop\developerPlatform\JobOffer.DAL\Database1.mdf;Integrated Security=True";

        public List<JobOfferDto> GetJoboffers() {
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    string query = "select * from JobOffers";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            JobOfferDto dto = new JobOfferDto();
                            dto.idJoboffer = reader.GetInt32(0);
                            dto.name = reader.GetString(1);
                            dto.description = reader.GetString(2);
                            dto.companyId = reader.GetInt32(3);
                            dto.catId = reader.GetInt32(4);
                            dto.applicationId = reader.GetInt32(5);
                            dto.jobType = reader.GetString(6);

                            allJobOffers.Add(dto);
                        }
                    }
                }
            }
            catch (SqlException exp)
            {
                
            }
            return allJobOffers;

        }
    }

}

