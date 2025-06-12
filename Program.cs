using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Manger maneger = new Manger();
            //maneger.Start();


            List<Person> hghg = GetPepoleDAL.GetAllPepole();
            foreach(var item in hghg)
            {
                Console.WriteLine(item);
            }
        }
    }

    
}
