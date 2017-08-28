using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
