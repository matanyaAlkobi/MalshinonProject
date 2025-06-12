using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MalshinonProject.DAL.IntelReportsTable;
using MalshinonProject.Entities;

namespace MalshinonProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Manger maneger = new Manger();
            //maneger.Start();


            List<IntelReprt> hghg = GetIntelReportDAL.GetAllIntelReports();
            foreach(var item in hghg)
            {
                Console.WriteLine(item);
            }
        }
    }

    
}
