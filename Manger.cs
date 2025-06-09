using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MalshinonProject
{
    internal class Manger
    {

        public void Start()
        {
            SetName();

        }

        public void SetName()
        {
            try
            {
                Console.WriteLine("Enter Your first name: ");
                string FN = Console.ReadLine();
                Console.WriteLine("please  enter ypur last name: ");
                string LN = Console.ReadLine();
                new Person(FN, LN);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"genral error: {ex}");
            }
        }
    }
}
