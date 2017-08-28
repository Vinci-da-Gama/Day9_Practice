using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Day9.L1ObjCollection;

namespace Day9.L9_L11
{
    class L11LinqRetrunObj
    {
        private List<OrdersObjL1> RetriveOrders()
        {
            GenerateOrders GetOrder = new GenerateOrders();
            return GetOrder.ConstructOrders();
        }

        public void ShowOrderDates()
        {
            List<OrdersObjL1> Orders = this.RetriveOrders();
            var od = from odate in Orders
                     select odate.OrderDate;
            foreach (var o in od)
            {
                Console.WriteLine("30 -- Order-Date : {0}.", o.ToShortDateString());
            }
            // select one sepcific column
            var od0 = from o in Orders
                      select o.OrderDate;

            // select multiple columns and return as annonymous type
            var od1 = from o in Orders
                      select new { o.OrderDate, o.OrderId };

            // select multiple columns and return as real new type
            var od2 = from o in Orders
                      select new Order_Summary { od = o.OrderDate, oi = o.OrderId };

            // 
        }
    }
}
