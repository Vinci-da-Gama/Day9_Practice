using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.L12_L13
{
    class L13_BuildInFunction
    {
        public void ShowBuildInFunction()
        {
            int[] Numbers = {33, 66, 88, 77, 99, 55, 100, 30, 80};
            
            var r0 = Numbers.Any();
            Console.WriteLine("Any Rz: {0}.", r0);
            var r1 = Numbers.All( a => a > 30);
            Console.WriteLine("ALL Rz: {0}.", r1);
            var r2 = Numbers.Contains(30);
            Console.WriteLine("Contains Rz: {0}.", r2);
            var r3 = Numbers.Count();
            Console.WriteLine("Count Rz: {0}.", r3);
            var r4 = Numbers.Sum();
            Console.WriteLine("Sum Rz: {0}.", r4);
            var r5 = Numbers.Min();
            Console.WriteLine("Min Rz: {0}.", r5);
            var r6 = Numbers.Max();
            Console.WriteLine("Max Rz: {0}.", r6);
            var r7 = Numbers.Average();
            Console.WriteLine("Average Rz: {0}.", r7);
            var r8 = Numbers.First();
            Console.WriteLine("First Rz: {0}.", r8);
            var r9 = Numbers.Last();
            Console.WriteLine("Last Rz: {0}.", r9);
            var r10 = Numbers.FirstOrDefault(o => o > 60);
            Console.WriteLine("FirstOrDefault Rz: {0}.", r10);
            var r11 = Numbers.LastOrDefault( b => b < 60 );
            Console.WriteLine("LastOrDefault Rz: {0}.", r11);
            var r12 = Numbers.Single(o => o > 99);
            Console.WriteLine("Single Rz: {0}.", r12);
            var r13 = Numbers.SingleOrDefault( o => o > 99 );
            Console.WriteLine("SingleOrDefault Rz: {0}.", r13);
            var r14 = Numbers.Aggregate(100, (o, p) => o > p? o: p);
            Console.WriteLine("Aggregate Rz: {0}.", r14);
            var r15 = Numbers.Aggregate(0, (o, p) => o += p);
            Console.WriteLine("Aggregate Rz: {0}.", r15);
        }
    }
}
