using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Day9.L1ObjCollection;
using Day9.Shared;

namespace Day9.L12_L13
{
    class L12_WhereClause
    {
        private List<OrdersObjL1> RetriveOrders()
        {
            GenerateOrders GetOrder = new GenerateOrders();
            return GetOrder.ConstructOrders();
        }
        #region Linq_and_method_syntax
        public void LinqQueryWhere()
        {
            List<OrdersObjL1> Orders = this.RetriveOrders();
            var o0 = from o in Orders
                     where o.OrderId == 1
                     select o;
            this.PrintRz(o0);

            var o1 = from o in Orders
                     where o.OrderDate > DateTime.Now.AddYears(-2) && o.OrderItems.Count > 1
                     select o;
            Console.WriteLine("29 -- later than 2 years and Count > 1");
            this.PrintRz(o1);

            var o2 = from o in Orders
                     where o.OrderDate < DateTime.Now.AddYears(-2) || o.OrderItems.Count > 2
                     select o;
            Console.WriteLine("35 -- later than 2 years Or Count > 2");
            this.PrintRz(o2);
        }
        public void MethodSyntaxWhere()
        {
            Console.WriteLine("Using Method Syntax...");
            List<OrdersObjL1> Orders = this.RetriveOrders();
            var o0 = Orders.Where(o => o.OrderId == 1).Select(p => p);
            this.PrintRz(o0);

            var o1 = Orders.Where(o => o.OrderDate > DateTime.Now.AddYears(2) && o.OrderItems.Count > 2);
            this.PrintRz(o1);

            var o2 = Orders.Where(o => o.OrderDate > DateTime.Parse("11/11/2014") || o.OrderItems.Count > 1);
            this.PrintRz(o2);

            // 2 wheres
            var o3 = Orders.Where(o => o.OrderDate > DateTime.Parse("12/12/2012")).Where(p => p.OrderItems.Count > 2);
            Console.WriteLine("54 -- 2 where clause.");
            this.PrintRz(o3);
        }
        #endregion
        private void PrintRz(IEnumerable<OrdersObjL1> o)
        {
            foreach (var os in o)
            {
                Console.WriteLine("\n61 L12_L13 -- OrderDate: {0} -- OrderAmount: {1}.", os.OrderDate.ToShortDateString(), os.OrderAmount);
            }
        }
        public void OpDataCrossTablesNLevels()
        {
            string pcmd = "FetchAllProducts";
            List<OrdersObjL1> Orders = this.RetriveOrders();
            Return_Data rd = new Return_Data(pcmd);
            List<Product> plist = new List<Product>();
            plist = rd.ReadAllProducts();

            var SummaryReport = from o in Orders
                                from i in o.OrderItems
                                join p in plist on i.OrderItemId equals p.pid
                                select new { p.pname, p.pqty, o.OrderId, i.OrderItemId };
            
            foreach (var rz in SummaryReport)
            {
                Console.WriteLine("77 -- ProductName: {0} -- Quantity: {1}.", rz.pname, rz.pqty.ToString());
            }

            // Split Table into two Then see the hierachy.
            var OrderItemsList = from o in Orders
                             from i in o.OrderItems
                             select i;
            var ProductAndOrderItems = from p in plist
                                       join v in OrderItemsList
                                       on p.pid equals v.OrderItemId
                                       into NewTable
                                       select new { p.pname, NewTable };
            string tab = new string(' ', 8);

            foreach (var a in ProductAndOrderItems)
            {
                Console.WriteLine(String.Format("96 -- PdName: {0}.", a.pname));
                foreach (var i in a.NewTable)
                {
                    Console.WriteLine(tab+"99 -- OrderItemId: {0} -- Quantity: {1}.", i.OrderItemId, i.Qty);
                }
            }

            // Method Syntax
            var SummaryReport0 = Orders.SelectMany(o => o.OrderItems.Join(plist, i => i.OrderItemId, j => j.pid, (i, j) => new { j.pname, i.OrderItemId, o.OrderAmount }));

            foreach (var i in SummaryReport0)
            {
                Console.WriteLine("109 -- ProductName: {0}, OrderAmount: {1}.", i.pname, i.OrderAmount);
            }

            // Group Join
            var SummaryReport1 = plist.GroupJoin(Orders.SelectMany(o => o.OrderItems), p => p.pid, m => m.OrderItemId, (p, NewTable0) => new { p.pid, p.pname, NewTable0 });

            foreach (var p in SummaryReport1)
            {
                if (p.pid <= 8)
                {
                    Console.WriteLine(String.Format("96 -- PdName: {0}.", p.pname));
                    foreach (var pd in p.NewTable0)
                    {
                        Console.WriteLine(tab + "99 -- OrderItemId: {0} -- Quantity: {1}.", pd.OrderItemId, pd.Qty);
                    }
                }
                else
                    return;
            }
        }
    }
}
