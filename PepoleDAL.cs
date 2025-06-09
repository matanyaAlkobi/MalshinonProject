using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //  Method for adding a person to the people table
        public static void AddPerson(Person person)
        {
            string connectionString = "server=localhost;user=root;password=;database=eagleeyedb";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Pepole (FirstName, LastName, SecretCode, Type) VALUES (@FirstName,@LastName, @SecretCode, @Type)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {


                        cmd.Parameters.AddWithValue("@FirstName", person.GetFirstName());
                        cmd.Parameters.AddWithValue("@LastName", person.GetLastName());
                        cmd.Parameters.AddWithValue("@SecretCode", person.GetSecretCode());
                        cmd.Parameters.AddWithValue("@Type", person.GetType());
                        cmd.ExecuteNonQuery();
                    }
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

        // Method for searching for people in a database
        public bool SearchForAPerson(string FirstName, string LastName)
        {
            string Query = "SELECT 1 " +
                "FROM  people " +
                "WHERE FirstName = @FN and LastName = @LN LIMIT 1";

            string connstring = "Server=127.0.0.1; database=Malshinon; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {

                    connection.Open();
                    using (var cmd = new MySqlCommand(Query, connection))
                    
                    {
                        cmd.Parameters.AddWithValue("@FN",FirstName);
                        cmd.Parameters.AddWithValue("@LN", LastName);
                        using (var reader = cmd.ExecuteReader())
                        {

                            return reader.HasRows;
                        }


                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return false;
            }
        }



    }
}

