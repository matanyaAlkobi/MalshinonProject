using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MalshinonProject
{
    internal class GetMalshinonDAl
    {
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


        //  A method that returns the number of reports
        public static int GetNumReports(string FirstName)
        {

            string Query = "SELECT NumReports " +
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
                                return reader.GetInt32("NumReports");
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


        // A method that returns the number of mentions
        public static int GetNumMention(string FirstName)
        {

            string Query = "SELECT NumMentions " +
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
                                return reader.GetInt32("NumMentions");
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


    }
}
