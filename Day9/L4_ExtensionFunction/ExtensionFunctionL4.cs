using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.L4_ExtensionFunction
{
    static class ExtensionFunctionL4
    {
        public static void PrintResultByUsingExtensionFunction(int Number)
        {
            Console.WriteLine("15 -- Number is: {0}.\n", Number);
            string rz = Number.Increament().Add5().Double().Decreament().ToString();
            Console.WriteLine("17 -- Result is: {0}.\n", rz);
        }

        private static int Increament(this int i)
        {
            return ++i;
        }

        private static int Decreament(this int j)
        {
            return --j;
        }

        private static int Add5(this int k)
        {
            return k+=5;
        }

        private static int Double(this int l)
        {
            return l * 2;
        }
    }
}
