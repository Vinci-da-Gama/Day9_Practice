using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.Shared
{
    class DelegateMethods
    {
        public static bool CheckStartwithLetter(string Name, string Letter)
        {
            return Name.StartsWith(Letter);
        }
        public static bool CheckEndwithLetter(string Name, string Letter)
        {
            return Name.EndsWith(Letter);
        }
        public static double plus(double n0, double n1) {
            return n0+n1;
        }
        public static double minus(double n0, double n1) {
            return n0-n1;
        }
        public static double multiple(double n0, double n1) {
            return n0*n1;
        }
        public static double devide(double n0, double n1) {
            return n0/n1;
        }
        public static void FirstUpper(string str) {
            char[] c = str.ToCharArray();
            int pos = 0;
            c[pos] = char.ToUpper(c[pos]);
            Console.WriteLine("FirstUppercase: {0}.", new string(c));
        }
        public static void LastUpper(string str) {
            char[] c = str.ToCharArray();
            int pos = c.Length - 1;
            c[pos] = char.ToUpper(c[pos]);
            Console.WriteLine("FirstUppercase: {0}.", new string(c));
        }
        public static void AllUpper(string str) {
            System.Console.WriteLine("Aoo Uppercase: {0}.", str.ToUpper());
        }
    }
}
