using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;

namespace MalshinonProject
{
    internal class Manger
    {

        public void Start()
        {
            Console.WriteLine("Enter Your first name: ");
            string FN = Console.ReadLine();
            Console.WriteLine("please  enter ypur last name: ");
            string LN = Console.ReadLine();
            if (!PepoleDAL.SearchForAPerson(FN, LN))
            {
                PepoleDAL.AddPerson(new Person(FN, LN));
            }
            string Report = SetIntelReport();
            List<string> targetFullNameList = SearchForTheName(Report);
            List<string> FNandLN = ExtractsFirstNameAndLastName(targetFullNameList);
            if (!PepoleDAL.SearchForAPerson(FNandLN[0], FNandLN[1]))
            {
                PepoleDAL.AddPerson(new Person(FNandLN[0], FNandLN[1],"Target"));

            }
        }

        // Requests information and returns the agent's name
        private string SetIntelReport()
        {
            string Report;
            do
            {
                Console.WriteLine("Please enter your report, and remember that the name starts with a capital letter.");
                Report = Console.ReadLine();
                if (SearchForTheName(Report).Count() < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("We were unable to capture your full name. Please enter the report again!. ");
                    Console.WriteLine("remember that the name starts with a capital letter.");
                    Console.ResetColor();
                }
            }
            while (SearchForTheName(Report).Count() < 2);
            return Report;


        }

        // Search ad for a person's name in uppercase letters
        // Returns a list of first and last names
        private List<string> SearchForTheName(string Report)
        {
            List<string> FullNameList = new List<string>();

            
                string[] text = Report.Split(' ');

                foreach (var word in text)
                {
                    if (word != "")
                    {
                        if (word[0] >= 65 && word[0] <= 90)
                        {
                            FullNameList.Add(word);
                        }
                    }
                }
            
            return FullNameList;
        }


        //Returns first name in first place and last name in second place
        private List<string> ExtractsFirstNameAndLastName(List<string> FullNameList)
        {
            string FirstName = "";
            if(FullNameList.Count() <= 2)
            {
                return FullNameList;
            }
            for (int i = 0; i < FullNameList.Count() - 1; i++)
            {
                FirstName += FullNameList[i] + " ";
            }
            List<string> FNandLN = new List<string> { FirstName, FullNameList[-1] };
            return FNandLN;
        }
    }
}
