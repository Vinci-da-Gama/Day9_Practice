using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.L567_Delegate_AnonymousMethod_lambda
{
    class L7FuncNLambda
    {
        public string[] CollectNames(Func<string, string, bool> Operation, string[] NamesArr, string Letter)
        {
            ArrayList Names = new ArrayList();
            string L = Letter;

            foreach (string SingleName in NamesArr)
            {
                if (Operation(SingleName, L))
                {
                    Names.Add(SingleName);
                }
            }

            return (string[])Names.ToArray(typeof(string));
        }

        public void ShowCalculateResult(Func<double, double, double> Calculate, double n0, double n1)
        {
             Console.WriteLine(String.Format("Result is: {0}.", Calculate(n0, n1).ToString()));
        }
    }
}
