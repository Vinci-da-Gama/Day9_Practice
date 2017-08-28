using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.Shared
{
    class PrintOutStringArr
    {
        public void PrintStrArr(string[] FitNames)
        {
            if(FitNames != null && FitNames.Length > 0) {
                foreach (string s in FitNames)
                {
                    Console.WriteLine("\nRz Name: {0}.\n", s);
                }
            }
        }
    }
}
