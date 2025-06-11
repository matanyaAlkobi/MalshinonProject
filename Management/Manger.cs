using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MalshinonProject.Management;
using Org.BouncyCastle.Crypto;

namespace MalshinonProject
{
    internal class Manger
    {
        private  string FN;
        string  LN;
        // System activation
        public void Start()
        {
            SetFirstName();
            SetLastName();
            if (!MalshinonDAL.SearchForAPerson(FN, LN))
            {
                InsertMalshinonDAL.AddPerson(new Person(FN, LN));
            }
            else if (GetMalshinonDAl.GetTypeByName(FN) == "Targt")
            {
                UpdateMalshinonDAL.ChangeTypeByNameSearch(FN,"Both");
            }

            string Report = SetIntelReport();
            List<string> targetFullNameList = SearchForTheName(Report);
            List<string> FNandLN = ExtractsFirstNameAndLastName(targetFullNameList);

            if (!MalshinonDAL.SearchForAPerson(FNandLN[0], FNandLN[1]))
            {
                InsertMalshinonDAL.AddPerson(new Person(FNandLN[0], FNandLN[1], "Target"));
            }
            else if (GetMalshinonDAl.GetTypeByName(FNandLN[0]) == "Reporter")
            {
                UpdateMalshinonDAL.ChangeTypeByNameSearch(FNandLN[0], "Both");
            }

            int ReporterID  = GetMalshinonDAl.GetAPersonID(FN);
            int TargetID  = GetMalshinonDAl.GetAPersonID(FNandLN[0]);
            InsertMalshinonDAL.AddingAReportToAIntelTable(ReporterID, TargetID, Report);

            int NumReport = GetMalshinonDAl.GetNumReports(FN);
            int NumMention = GetMalshinonDAl.GetNumMention(FNandLN[0]);
            UpdateMalshinonDAL.IncreasingNumReportByOne(NumReport, FN);
            UpdateMalshinonDAL.IncreasingNumMentionByOne(NumMention, FNandLN[0]);

            var LengthAndNum = GetMalshinonDAl.GetLengthAndNumReport(ReporterID);
            double avg = Calculator.GetAverage(LengthAndNum.CharacterIength, LengthAndNum.NumReport);
            if(LengthAndNum.NumReport >=  10 && avg >= 100)
            {
                Console.WriteLine($"This {FN} is a potential agent.");
                UpdateMalshinonDAL.ChangeTypeByNameSearch(FN, "PotentialAgent");
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

            try
            {


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
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return FullNameList;
            }
        }


        //Returns first name in first place and last name in second place
        private List<string> ExtractsFirstNameAndLastName(List<string> FullNameList)
        {
            string FirstName = "";
            if(FullNameList.Count() <= 2)
            {
                return FullNameList;
            }
            for (int i = 0; i < FullNameList.Count- 2; i++)
            {
                FirstName += FullNameList[i] + " ";
            }
                List<string> FNandLN = new List<string> { FirstName, FullNameList[FullNameList.Count - 1] };
            return FNandLN;
        }

        private void SetFirstName()
        {
            do
            {
                Console.WriteLine("Enter Your first name: ");
                this.FN = Console.ReadLine();
                if(FN == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error!! Please enter the first name again. ");
                    Console.ResetColor();
                }

            }
            while (FN == "");
            //FN = Person.MakeAFirstLetterCapital(FN);
        }

        private void SetLastName()
        {
            do
            {
                Console.WriteLine("Enter Your first name: ");
                this.LN = Console.ReadLine();
                if (LN == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error!! Please enter the last name again. ");
                    Console.ResetColor();
                }

            }
            while (LN == "");
            //FN = Person.MakeAFirstLetterCapital(LN);
        }
    }
}
