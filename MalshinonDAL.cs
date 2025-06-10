using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;

namespace MalshinonProject
{
    internal class MalshinonDAL
    {

        private readonly string connStr = "server=localhost;user=root;password=;database=Malshinon";

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


                        cmd.Parameters.AddWithValue("@FirstName", person.GetFirstName());
                        cmd.Parameters.AddWithValue("@LastName", person.GetLastName());
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

        // Method for searching for people in a database
        public static bool SearchForAPerson(string FirstName, string LastName)
        {
            string Query = "SELECT 1 " +
                "FROM  people " +
                "WHERE FirstName = @FN and LastName = @LN LIMIT 1";

            string connstring = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FN", FirstName);
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

        // A method that receiving a first name and returns the person's ID.
        public static int GetAPersonID(string FirstName)
        {

            string Query = "SELECT ID " +
                            "FROM  people " +
                            "WHERE FirstName = @FN LIMIT 1";

            string connstring = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FN", FirstName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("ID");
                            }
                            return -1;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return -1;
            }
        }


        //public static void InsertingAReportIntoATable()
        //{
        //    string connectionString = "Server=localhost; database=Malshinon; UID=root; password=";
        //    try
        //    {
        //        using (var connection = new MySqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            string query = "INSERT INTO intelreports (ID, ReporterID, TargetID, Text) VALUES (@ID,@ReporterID, @TargetID, @Text)";
        //            using (var cmd = new MySqlCommand(query, connection))
        //            {


        //                cmd.Parameters.AddWithValue("@ID", person.GetFirstName());
        //                cmd.Parameters.AddWithValue("@ReporterID", person.GetLastName());
        //                cmd.Parameters.AddWithValue("@TargetID", person.GetSecretCode());
        //                cmd.Parameters.AddWithValue("@Text", person.GetType());
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //        Console.WriteLine("Intel report added successfully");

        //    }
        //    catch (MySqlException ex)
        //    {
        //        Console.WriteLine("MySQL Error: " + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("General Error: " + ex.Message);
        //    }

        //}


        //  A method that displays status by name search
        public static string GetTypeByName(string FirstName)
        {
            string Query = "SELECT Type " +
                            "FROM  people " +
                            "WHERE FirstName = @FN LIMIT 1";

            string connstring = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FN", FirstName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetString("Type");
                            }
                            return "";
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return "";
            }
        }


        //  A method that changes the person's type based on a name search
        public static void ChangeTypeByNameSearch(string FirstName, string Type)
        {
            string Query = "UPDATE people " +
                "SET Type = @Type " +
                "WHERE FirstName = @FN;";

            string connstring = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FN", FirstName);
                        cmd.Parameters.AddWithValue("@Type", Type);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("The type has been changed successfully!");
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


