using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalshinonProject.Entities;
using MySql.Data.MySqlClient;

namespace MalshinonProject.DAL.IntelReportsTable
{
    internal class GetIntelReportDAL
    {
        //  Returns a tuple of the length of the label and the number of reports.
        public static (int NumReport, int CharacterIength) GetLengthAndNumReport(int ReporterID)
        {
            int NumReport = 0;
            int CharacterIength = 0;
            string Query = "SELECT I.Text, peopleTable.NumReports,CHAR_LENGTH(I.Text) AS CharacterIength FROM intelreports AS I INNER JOIN people AS peopleTable ON peopleTable.ID = I.ReporterID WHERE I.ReporterID = @ID;";

            string connstring = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", ReporterID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                while (reader.Read())
                                {
                                    CharacterIength = reader.GetInt32("CharacterIength");
                                }
                                NumReport = reader.GetInt32("NumReports");
                                Console.WriteLine("Get length and num reports succeeded! ");
                                return (NumReport, CharacterIength);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            return (NumReport, CharacterIength);

        }


        // Returns all intelReport table in a list
        public static List<IntelReprt> GetAllIntelReports()
        {

            List<IntelReprt> AllIntelReport = new List<IntelReprt>();
            string Query = "SELECT * " +
                            "FROM  intelreports ";

            string connstring = "Server=localhost; database=Malshinon; UID=root; password=";
            try
            {
                using (var connection = new MySqlConnection(connstring))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(Query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int ID = reader.GetInt32("ID") != null ? reader.GetInt32("ID") : 0;
                                int ReporterID = reader.GetInt32("ReporterID") != null ? reader.GetInt32("ReporterID") : 0;
                                int TargetID = reader.GetInt32("TargetID") != null ? reader.GetInt32("TargetID") : 0;
                                string Text = reader.GetString("Text") != null ? reader.GetString("Text") : "";
                                DateTime TimeStamp = reader.GetDateTime("TimeStamp") != null ? reader.GetDateTime("TimeStamp") : DateTime.Now;
                                AllIntelReport.Add(new IntelReprt(ID, ReporterID, TargetID, Text, TimeStamp));
                            }
                            Console.WriteLine("Get all intelReports succeeded!");
                        }
                    }
                }
                return AllIntelReport;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            return AllIntelReport;
        }




    }
}
