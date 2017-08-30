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
                Console.WriteLine("27 -- Order-Date : {0}.", o.ToShortDateString());
            }
            // select one sepcific column
            var od0 = from o in Orders
                      select o.OrderDate;
            foreach(DateTime dt in od0)
            {
                Console.WriteLine("\n34 -- date is: {0}.", dt.ToShortDateString());
            }

            // select multiple columns and return as annonymous type
            var od1 = from o in Orders
                      select new { o.OrderDate, o.OrderId };
            foreach (var ds in od1)
            {
                Console.WriteLine("\n42 -- date is: {0} --- id is: {1}", ds.OrderDate.ToShortDateString(), ds.OrderId.ToString());
            }

            // select multiple columns and return as real new type
            var od2 = from o in Orders
                      select new Order_Summary { od = o.OrderDate, oi = o.OrderId };
            foreach (Order_Summary os in od2)
            {
                Console.WriteLine("\n50 -- date is: {0} --- id is: {1}", os.od.ToShortDateString(), os.oi.ToString());
            }

            // xmlElement
            var OrderXml = new XElement("Orders", from o in Orders
                                                  select new XElement("Order", new XAttribute("OrderDate", o.OrderDate), new XAttribute("TotalItems", o.OrderItems.Sum(i => i.Qty)) ));
            Console.WriteLine(String.Format("\nXml_Order is: {0}.", OrderXml.ToString()));

            // method syntax
            foreach (var o in Orders.Select(o => o))
            {
                Console.WriteLine("61 -- Orders Date is: {0}", o.OrderDate.ToShortDateString());
            }

            foreach (var o in Orders.Select(o => o.OrderDate))
            {
                Console.WriteLine("66 -- Orders Date is: {0}", o.ToShortDateString());
            }

            foreach (var o in Orders.Select(o => new { o.OrderDate, o.OrderAmount }))
            {
                Console.WriteLine("66 -- Orders Date is: {0} -- Order Amount: {1}.", o.OrderDate.ToShortDateString(), o.OrderAmount.ToString());
            }

            foreach (Order_Summary os in Orders.Select(o => new Order_Summary { oi = o.OrderId, od = o.OrderDate }))
            {
                Console.WriteLine("76 -- Orders Date is: {0} -- OrderId: {1}.", os.od.ToShortDateString(), os.oi.ToString());
            }

            var XmlElem0 = new XElement("XmlOrders", Orders.Select(o => new XElement("XOs", new XAttribute("OrderDate", o.OrderDate), new XAttribute("Total_Items", o.OrderItems.Sum(i => i.Qty)) )));
            Console.WriteLine("\n80 -- XmlElem0: {0}.", XmlElem0.ToString());

            // SelectMany --> jump over level to select
            var d = Orders.SelectMany(o => o.OrderItems);
            foreach (var i in d)
            {
                Console.WriteLine("\n86 -- Item Id: {0} -- ProductName: {1} -- Quantity: {2}.", i.OrderItemId.ToString(), i.ProductName, i.Qty.ToString());
            }

        }
    }
}
