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
using MalshinonProject.DAL.IntelReportsTable;
using MalshinonProject.Management;
using Org.BouncyCastle.Crypto;

namespace MalshinonProject
{
    internal class Manger
    {
        string ReporterFN;
        string ReporterLN;

        // System activation
        public void Start()
        {
            SetFirstName();
            SetLastName();
            if (!PepoleDAL.SearchForAPerson(ReporterFN, ReporterLN))
            {
                InsertPepoleDAL.AddPerson(new Person(ReporterFN, ReporterLN));
            }
            else if (GetPepoleDAL.GetTypeByName(ReporterFN) == "Targt")
            {
                UpdatePepoleDAL.ChangeTypeByNameSearch(ReporterFN, "Both");
            }

            string Report = SetIntelReport();
            List<string> targetFullNameList = SearchForTheName(Report);
            List<string> TargetFNandLN = ExtractsFirstNameAndLastName(targetFullNameList);

            if (!PepoleDAL.SearchForAPerson(TargetFNandLN[0], TargetFNandLN[1]))
            {
                InsertPepoleDAL.AddPerson(new Person(TargetFNandLN[0], TargetFNandLN[1], "Target"));
            }
            else if (GetPepoleDAL.GetTypeByName(TargetFNandLN[0]) == "Reporter")
            {
                UpdatePepoleDAL.ChangeTypeByNameSearch(TargetFNandLN[0], "Both");
            }

            int ReporterID  = GetPepoleDAL.GetAPersonID(ReporterFN);
            int TargetID  = GetPepoleDAL.GetAPersonID(TargetFNandLN[0]);
            InsertIntelRepotrsDAL.AddingAReportToAIntelTable(ReporterID, TargetID, Report);

            int NumReport = GetPepoleDAL.GetNumReports(ReporterFN);
            int NumMention = GetPepoleDAL.GetNumMention(TargetFNandLN[0]);
            UpdatePepoleDAL.IncreasingNumReportByOne(NumReport, ReporterFN);
            UpdatePepoleDAL.IncreasingNumMentionByOne(NumMention, TargetFNandLN[0]);

            var LengthAndNum = GetIntelReportDAL.GetLengthAndNumReport(ReporterID);
            double avg = Calculator.GetAverage(LengthAndNum.CharacterIength, LengthAndNum.NumReport);
            if(LengthAndNum.NumReport >=  10 && avg >= 100)
            {
                Console.WriteLine($"This {ReporterFN} is a potential agent.");
                UpdatePepoleDAL.ChangeTypeByNameSearch(ReporterFN, "PotentialAgent");
            }
            if(NumMention >= 20)
            {
                Console.WriteLine($"Warning: {TargetFNandLN[0]} is a potential threat.");
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
                List<string> TargetFNandLN = new List<string> { FirstName, FullNameList[FullNameList.Count - 1] };
            return TargetFNandLN;
        }

        private void SetFirstName()
        {
            do
            {
                Console.WriteLine("Enter Your first name: ");
                this.ReporterFN = Console.ReadLine();
                if(ReporterFN == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error!! Please enter the first name again. ");
                    Console.ResetColor();
                }

            }
            while (ReporterFN == "");
        }

        private void SetLastName()
        {
            do
            {
                Console.WriteLine("Enter Your last name: ");
                this.ReporterLN = Console.ReadLine();
                if (ReporterLN == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error!! Please enter the last name again. ");
                    Console.ResetColor();
                }

            }
            while (ReporterLN == "");
            
        }
    }
}
