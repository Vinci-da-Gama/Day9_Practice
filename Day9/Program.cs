using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Day9.L1ObjCollection;
using Day9.L3_AnonymousType;
using Day9.L4_ExtensionFunction;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Different_Ways_ToDo_AnonymoueType
            // 1. Standard constructor
            OrdersObjL1 Order0 = new OrdersObjL1();
            Order0.OrderId = 1;
            Order0.OrderDate = DateTime.Now;

            // 2. Overloaded Constructor
            OrdersObjL1 Order1 = new OrdersObjL1(2, DateTime.Now);

            // 3. two Arraies
            int[] Nums = { 31, 32, 33 };
            string[] States = {"State0", "State1", "State2"};

            // 4, Implicity Call Constructor
            OrdersObjL1 Order2 = new OrdersObjL1 { OrderId = 3, OrderDate = DateTime.Now, CustomerName = "Cust0", OrderAmount = 359.00M };

            // 5. Explicity Call Constructor
            OrdersObjL1 Order3 = new OrdersObjL1() { OrderId = 4, OrderDate = DateTime.Now, CustomerName = "Cust1", OrderAmount = 299.00M };

            // 6. Nested Obj
            OrdersObjL1 Order4 = new OrdersObjL1 {
                BillingAddress = new OrderAddressL1 { Address1 = "b-address1", City = "b-City1", State = "b-State1", Zip = "b-Zip1" },
                ShippingAddress = new OrderAddressL1 { Address1 = "s-adress1", City = "s-City1", State = "s-State1", Zip = "s-Zip1" }
            };

            // 7. Obj Collection
            OrdersObjL1 Order5 = new OrdersObjL1()
            {
                OrderItems = new List<OrderItemL1>
                {
                    new OrderItemL1() { OrderItemId = 0, ProductName = "PdName0", Qty = 1 },
                    new OrderItemL1 { OrderItemId = 1, ProductName = "PdName1", Qty = 2 },
                    new OrderItemL1 { OrderItemId = 2, ProductName = "PdName2", Qty = 3 }
                }
            };

            // 8. Work With Any Type IEnumerable
            List<int> newNumbsAry = new List<int> { 33, 34, 35 };
            ArrayList ObjArr = new ArrayList { Order0, Order1, Order2, Order3, Order4, Order5 };

            Console.WriteLine(String.Format("The Length of ObjArr is: {0}.", ObjArr.Count));
            #endregion

            Console.WriteLine("The Purpose of Anonymous Type is about re-format Complex Obj.");
            AnonymousTypeL3 at3 = new AnonymousTypeL3();
            at3.ShowOrdersAccordingToAnonymouseType();

            ExtensionFunctionL4.PrintResultByUsingExtensionFunction(10);

            Console.ReadLine();
        }
    }
}
