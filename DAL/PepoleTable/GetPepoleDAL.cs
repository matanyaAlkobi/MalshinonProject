﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MalshinonProject
{
    internal class GetPepoleDAL
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

        // Returns all people table in a list
        public static List<Person> GetAllPepole()
        {

            List<Person> AllPersons = new List<Person>();
            string Query = "SELECT * " +
                            "FROM  people ";

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
                                string FirstName = reader.GetString("FirstName") != null ? reader.GetString("FirstName") : "";
                                string LastName = reader.GetString("LastName") != null ? reader.GetString("LastName") : "";
                                string SecretCode = reader.GetString("SecretCode") != null ? reader.GetString("SecretCode") : "";
                                string Type = reader.GetString("Type") != null ? reader.GetString("Type") : "";
                                int NumReport = reader.GetInt32("NumReports") != null ? reader.GetInt32("NumReports") : 0;
                                int NumMention = reader.GetInt32("NumMentions") != null ? reader.GetInt32("NumMentions") : 0;
                                AllPersons.Add(new Person(ID, FirstName, LastName, SecretCode, Type, NumReport, NumMention));
                            }
                            Console.WriteLine("Get all pepole succeeded!");
                        }
                    }
                }
                return AllPersons;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            return AllPersons;
        }





    }
}

