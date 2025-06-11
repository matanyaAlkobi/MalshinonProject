using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MalshinonProject
{
    internal class InsertPepoleDAL
    {
        //  Method for adding a person to the people table
        public static void AddPerson(Person person)
        {
            string connectionString = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {


                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO People (FirstName, LastName, SecretCode, Type) VALUES (@FirstName,@LastName, @SecretCode, @Type)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {


                        cmd.Parameters.AddWithValue("@FirstName", Person.MakeAFirstLetterCapital(person.GetFirstName()));
                        cmd.Parameters.AddWithValue("@LastName", Person.MakeAFirstLetterCapital(person.GetLastName()));
                        cmd.Parameters.AddWithValue("@SecretCode", person.GetSecretCode());
                        cmd.Parameters.AddWithValue("@Type", person.GetType());
                        int Execution = cmd.ExecuteNonQuery();  // צריך  לטפל

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


    }
}
