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
        string FirstName;
        string LastName;
        string SecretCode;
        string Type;

        private string RandomString(int size)
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

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public string GetSecretCode()
        {
            return SecretCode;
        }

        public new string GetType()
        {
            return Type;
        }

        public static string MakeAFirstLetterCapital(string text)
        {
            text.ToLower();
            char FirstLetterUpper = char.ToUpper(text[0]);
            string NewText = FirstLetterUpper.ToString() + text.Substring(1);
            return NewText;
        }
        

    }

    
}
