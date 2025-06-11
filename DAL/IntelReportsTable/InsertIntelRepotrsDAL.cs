using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MalshinonProject.DAL.IntelReportsTable
{
    internal class InsertIntelRepotrsDAL
    {
        // Method that adds a report to the IntelReport table
        public static void AddingAReportToAIntelTable(int ReporterID, int TargetID, string Report)
        {
            string connectionString = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {


                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO intelreports (ReporterID, TargetID, Text) VALUES (@ReporterID,@TargetID, @Report)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {

                        cmd.Parameters.AddWithValue("@ReporterID", ReporterID);
                        cmd.Parameters.AddWithValue("@TargetID", TargetID);
                        cmd.Parameters.AddWithValue("@Report", Report);
                        int Execution = cmd.ExecuteNonQuery();  // צריך  לטפל
                    }
                }
                Console.WriteLine("Report added successfully");

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
