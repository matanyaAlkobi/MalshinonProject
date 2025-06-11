using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MalshinonProject
{

    internal class UpdatePepoleDAL
    {

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


        public static void IncreasingNumReportByOne(int NumReports, string FirstName)
        {
            string connectionString = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE People " +
                        "SET NumReports = @NumReports " +
                        "WHERE FirstName = @FN";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NumReports", NumReports + 1);
                        cmd.Parameters.AddWithValue("@FN", FirstName);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("NumReports increased by one successfully");

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

        public static void IncreasingNumMentionByOne(int NumReports, string FirstName)
        {
            string connectionString = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE People SET NumMentions = @NumMentions WHERE FirstName = @FN";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NumMentions", NumReports + 1);
                        cmd.Parameters.AddWithValue("@FN", FirstName);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("NumMentions increased by one successfully");
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
