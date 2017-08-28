using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.L9_L11
{
    class L9Linq
    {
        public void ShowAllCountries()
        {
            string Gac = "GrabAllCountries";
            FetchCountries fc = new FetchCountries(Gac);
            string[] Countries = fc.SetCountriesArr();
            
            Console.WriteLine("17 -- First Country: {0}.", Countries[0]);

            // Linq Syntax
            var uCountries0 = from u in Countries
                                   where u.StartsWith("U")
                                   select u;

            this.LoopRz(uCountries0);

            // method syntax
            var uCountries1 = Countries.Where(c => c.StartsWith("U"));

            this.LoopRz(uCountries1);

            // method syntax in processing
            foreach (string ucs in Countries.Where(c => c.StartsWith("U")))
            {
                Console.WriteLine("34 -- ucs is: {0}.", ucs);
            }

            // length > 5
            foreach (string ucs in Countries.Where(p => p.Length > 5))
            {
                Console.WriteLine("40 -- ucs is: {0}.", ucs);
            }

            // Linq Quey Syntax length > 5
            var CountriesLengthGt5 = from cl5 in Countries
                                     where cl5.Length > 5
                                     select cl5;

            this.LoopRz(CountriesLengthGt5);

            // Alphabet Order Sord
            Console.WriteLine("\n");
            foreach (string ucs in Countries.OrderBy(a => a))
            {
                Console.WriteLine("54 -- ucs is: {0}.", ucs);
            }

            // reverse order
            Console.WriteLine("\n");
            foreach (string ucs in Countries.OrderByDescending(a => a))
            {
                Console.WriteLine("61 -- ucs is: {0}.", ucs);
            }

            // skip
            Console.WriteLine("\n");
            foreach (string u in Countries.Skip(3))
            {
                Console.WriteLine("68 -- ucs is: {0}.", u);
            }

            // take
            Console.WriteLine("\n");
            foreach (string c in Countries.Take(3))
            {
                Console.WriteLine("75 -- First 3 countries is: {0}.", c);
            }

            // first
            Console.WriteLine("\n First country is: {0}.", Countries.First());

            // And Linq Query
            var c0 = from c in Countries
                     where c.StartsWith("U") && c.Length > 5
                     select c;

            this.LoopRz(c0);

            // And Method Syntax
            Console.WriteLine("\n");
            foreach (string c in Countries.Where(p => p.StartsWith("U") && p.Length > 5))
            {
                Console.WriteLine("92 -- First 3 countries is: {0}.", c);
            }

            // Linq Query Order
            var c1 = from c in Countries
                     orderby c
                     select c;

            this.LoopRz(c1);

            // Linq Query Reverse Order
            var c2 = from c in Countries
                     orderby c descending
                     select c;
            this.LoopRz(c2);

            // Linq Query Skip
            var c3 = from c in Countries.Skip(3)
                     select c;
            this.LoopRz(c3);

            // Linq Query Take
            var c4 = from c in Countries.Take(3)
                     select c;
            this.LoopRz(c4);

        }

        #region Inner_Functions
        private void LoopRz(IEnumerable<string> Countries)
        {
            foreach (string uc in Countries)
            {
                Console.WriteLine("39 -- Country is: {0}.", uc.ToString());
                Console.WriteLine("\n");
            }
        }
        #endregion

    }
}
