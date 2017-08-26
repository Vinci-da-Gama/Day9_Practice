using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Day9.L1ObjCollection;

namespace Day9.L3_AnonymousType
{
    class AnonymousTypeL3
    {
        private List<OrdersObjL1> RetriveOrders()
        {
            GenerateOrders GetOrder = new GenerateOrders();
            return GetOrder.ConstructOrders();
        }

        public void ShowOrdersAccordingToAnonymouseType()
        {
            List<OrdersObjL1> Orders = this.RetriveOrders();
            Random Rnum = new Random();
            Console.WriteLine("22 -- Use Anonymous Type to Re-Shape Properties We want to display...");
            int ItemNum = Rnum.Next(0, 2);
            var OdList = from o in Orders
                         select new {
                             OrderId = o.OrderId,
                             CustomerName = o.CustomerName,
                             OrderDate = o.OrderDate,
                             PdName = o.OrderItems[ItemNum].ProductName,
                             PdQty = o.OrderItems.Sum(p => p.Qty)
                         };
            Console.WriteLine(String.Format("Now, Type of OdList: {0}", OdList.GetType()));
            foreach (var Od in OdList)
            {
                Console.WriteLine(String.Format("OrderId -- {0}, Customername -- {1}, OrderDate -- {2}, Productname -- {3}, Qty -- {4}.", Od.OrderId, Od.CustomerName, Od.OrderDate, Od.PdName, Od.PdQty));
            }
        }

    }
}
