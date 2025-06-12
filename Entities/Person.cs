using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Compiler;
using ZstdSharp.Unsafe;

namespace MalshinonProject
{
    internal class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecretCode { get; set; }


        public string Type { get; set; }
        public int NumReport { get; set; }
        public int NumMention { get; set; }


        private static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }


        public Person(string FirstName, string LastName, string Type = "Reporter")
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Type = Type;
            this.SecretCode = RandomString(10);
        }


        public Person(int ID, string FirstName, string LastName, string SecretCode, string Type, int NumReport, int NumMention)
        {
            {
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.SecretCode = SecretCode;
                this.Type = Type;
                this.NumReport = NumReport;
                this.NumMention = NumMention;
            }
        }

        //public string GetFirstName()
        //{
        //    return FirstName;
        //}

        //public string GetLastName()
        //{
        //    return LastName;
        //}

        //public string GetSecretCode()
        //{
        //    return SecretCode;
        //}

        //public new string GetType()
        //{
        //    return Type;
        //}

        public static string MakeAFirstLetterCapital(string text)
        {
            text.Trim();
            text.TrimEnd();
            text.ToLower();
            char FirstLetterUpper = char.ToUpper(text[0]);
            string NewText = FirstLetterUpper.ToString() + text.Substring(1);
            return NewText;
        }


        public override string ToString()
        {
            return $"ID: {ID} FirstName: {FirstName} LastName: {LastName} SecretCode: {SecretCode} Type: {Type} NumReport: {NumReport} NumMention: {NumMention}";
        }

    }

    
}
