using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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

        }
        private string Intel()
        {
            string TargetName = "";
            Console.WriteLine("What is your intel report?");
            string Report = Console.ReadLine();

            string[] text = Report.Split(' ');

            foreach(var word in text)
            {
                if (word != "")
                {
                    if (word[0] >= 65 && word[0] <= 90)
                    {
                        TargetName += word + " ";
                    }
                }
            }
            return TargetName;

        }


    }
}
