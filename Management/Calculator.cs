using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalshinonProject.Management
{
    internal class Calculator
    {

        public static double GetAverage(int num1, int num2)
        {
            
            if (num2 == 0)
            {
                return 0;
            }
            Double avg = num1 / num2;

            return avg;
        }

            
    }
}
