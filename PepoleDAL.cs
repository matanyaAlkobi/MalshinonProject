using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MalshinonProject
{
    internal class PepoleDAL
    {

        private readonly string connStr = "server=localhost;user=root;password=;database=Malshinon";


        public static void AddPerson(Person person)
        {
            string connectionString = "server=localhost;user=root;password=;database=eagleeyedb";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO agent (FirstName, LastName, SecretCode) VALUES (@FirstName,@LastName, @SecretCode, @Type)";
                    var cmd = new MySqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@FirstName", person.GetFirstName());
                    cmd.Parameters.AddWithValue("@LastName", person.GetLastName());
                    cmd.Parameters.AddWithValue("@SecretCode", person.GetSecretCode());
                    cmd.Parameters.AddWithValue("@Type", person.GetType());
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("person added successfully");

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }

        }
    }
}

