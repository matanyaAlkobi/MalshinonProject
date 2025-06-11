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
    internal class PepoleDAL
    {

        //private readonly string connStr = "server=localhost;user=root;password=;database=Malshinon";



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



        
       

        

        

        
    }

}


