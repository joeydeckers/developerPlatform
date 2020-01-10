using System;
using System.Collections.Generic;
using Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public class JobOfferDatabaseHandler: DataHandler
    {

        public JobOfferDatabaseHandler(string conString)
        {
            //DataHandler.SetConnectionString(config["ConnectionStrings:database"]);
            DataHandler.SetConnectionString(conString);

        }

        public List<JobOfferDto> GetJoboffers() {
            List<JobOfferDto> allJobOffers = new List<JobOfferDto>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                    string query = "select * from joboffers";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        MySqlDataReader reader = command.ExecuteReader();
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
            catch (MySqlException exp)
            {
                
            }
            return allJobOffers;

        }

        public JobOfferDto GetJoboffer(int id)
        {
            JobOfferDto dto = new JobOfferDto();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "select * from joboffers where idJoboffer = " + id;
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        MySqlDataReader reader = command.ExecuteReader();
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

            catch (MySqlException exp)
            {

            }
            return dto;
        }

        public void AddJobOffer(string name, string description, int companyId, int catId, int applicationId, string jobType)
        {
            string query = "insert into joboffers(name, description, companyId, catId, applicationId, jobType) values( @Name, @Description, @CompanyId, @CatId, @ApplicationId, @JobType)";

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@CompanyId", companyId);
            cmd.Parameters.AddWithValue("@CatId", catId);
            cmd.Parameters.AddWithValue("@ApplicationId", applicationId);
            cmd.Parameters.AddWithValue("@JobType", jobType);

            cmd.ExecuteReader();
        }

        public bool UpdateJobOffer(string name, string description, int companyId, int catId, int applicationId, string jobType)
        {
            string query = "UPDATE joboffers(name, description, companyId, catId, applicationId, jobType) values( @Name, @Description, @CompanyId, @CatId, @ApplicationId, @JobType) WHERE companyId = " + companyId;

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Parameters.AddWithValue("@CatId", catId);
                cmd.Parameters.AddWithValue("@ApplicationId", applicationId);
                cmd.Parameters.AddWithValue("@JobType", jobType);

                cmd.ExecuteReader();

                return true;
            }

            catch (MySqlException exp)
            {
                return false;
            }

            return true;
        }


        public bool DeleteJobOffer(int companyId, int jobOfferId)
        {
            //string query = "DELETE FROM JobOffers WHERE companyId =  @CompanyId AND idJoboffer = @JobOfferId";
            string query = "DELETE FROM joboffers WHERE companyId = " + companyId + " AND idJoboffer = "+ jobOfferId;

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CompanyId", companyId);
                cmd.Parameters.AddWithValue("@JobOfferId", jobOfferId);

                cmd.ExecuteReader();
            }
            catch (MySqlException exp)
            {
                return false;
            }
            return true;


        }
    }

}

