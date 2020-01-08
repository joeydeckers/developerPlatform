using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ApplicationDatabaseHandler:DataHandler
    {

        public ApplicationDatabaseHandler(string conString)
        {
            DataHandler.SetConnectionString(conString);
        }
        public List<ApplicationDto> GetAllApplications()
        {
            List<ApplicationDto> allApplications = new List<ApplicationDto>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "select * from applications";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        MySqlDataReader reader = command.ExecuteReader();
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
            catch (MySqlException exp)
            {
               
            }
            return allApplications;
        }

        public ApplicationDto GetApplication(int id)
        {
            ApplicationDto dto = new ApplicationDto();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "select * from applications where idApplication = " + id;
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            dto.IdApplication = reader.GetInt32(0);
                            dto.UserId = reader.GetInt32(1);
                            dto.JobofferId = reader.GetInt32(2);
                            dto.ApplicationText = reader.GetString(3);
                        }
                    }
                }
            }

            catch (MySqlException exp)
            {

            }
            return dto;
        }

        public void CreateApplication(int userId, int jobOfferId, string applicationText)
        {
            string query = "insert into applications(userId, jobOfferId, applicationText) values( @UserId, @JobOfferId, @ApplicationText)";

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@JobOfferId", jobOfferId);
            cmd.Parameters.AddWithValue("@ApplicationText", applicationText);
            cmd.ExecuteReader();
        }
    }
}
