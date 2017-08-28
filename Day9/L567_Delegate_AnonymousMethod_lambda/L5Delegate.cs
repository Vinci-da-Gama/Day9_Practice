using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Day9.Shared;

namespace Day9.L567_Delegate_AnonymousMethod_lambda
{
    class L5Delegate
    {
        public string[] NamesArr { get; set; }
        public string Letter { get; set; }

        public L5Delegate(string[] Names, string L)
        {
            NamesArr = Names;
            Letter = L;
        }

        public delegate bool CheckLetterInNames(string Name, string Letter);
        public string[] CollectNames(CheckLetterInNames CheckFunction)
        {
            ArrayList Names = new ArrayList();

            foreach (string SingleName in NamesArr)
            {
                if(CheckFunction(SingleName, Letter)) {
                    Names.Add(SingleName);
                }
            }

            return (string[])Names.ToArray(typeof(string));
        }

        public delegate double Calculate(double n0, double n1);
        public void DoCalculate(Calculate cal, double n0, double n1)
        {
            double rz = cal(n0, n1);
            Console.WriteLine("Calculate Result is: {0}.", rz.ToString());
        }

    }
}
