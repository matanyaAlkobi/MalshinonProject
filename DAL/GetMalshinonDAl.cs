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
                                Console.WriteLine("Get type  by name succeeded!");
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
                                Console.WriteLine("Get person ID succeeded!");
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
                                Console.WriteLine("get Num Reports succeeded! ");
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
                                Console.WriteLine("Get num mentions succeeded! ");
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

    }
}
