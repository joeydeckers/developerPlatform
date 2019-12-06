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

        // dit moet op een andere manier want nu moet ik altijd het pad aanpassen
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
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            JobOfferDto dto = new JobOfferDto();
                            dto.IdJoboffer = reader.GetInt32(0);
                            dto.Name = reader.GetString(1);
                            dto.Description = reader.GetString(2);
                            dto.CompanyId = reader.GetInt32(3);
                            dto.CatId = reader.GetInt32(4);
                            dto.ApplicationId = reader.GetInt32(5);
                            dto.JobType = reader.GetString(6);

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

        public JobOfferDto GetJoboffer(int id)
        {
            JobOfferDto dto = new JobOfferDto();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "select * from JobOffers where idJoboffer = " + id;
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            dto.IdJoboffer = reader.GetInt32(0);
                            dto.Name = reader.GetString(1);
                            dto.Description = reader.GetString(2);
                            dto.CompanyId = reader.GetInt32(3);
                            dto.CatId = reader.GetInt32(4);
                            dto.ApplicationId = reader.GetInt32(5);
                            dto.JobType = reader.GetString(6);
                        }
                    }
                }
            }

            catch (SqlException exp)
            {

            }
            return dto;
        }

        public void AddJobOffer()
        {
            string query = "insert into JobOffers(name, description, companyId, catId, applicationId, jobType) values( 'ios', 'hallo', 1, 1, 2, 'fulltime')";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteReader();
        }
    }

}

