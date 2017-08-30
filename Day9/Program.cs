using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Day9.L1ObjCollection;
using Day9.L3_AnonymousType;
using Day9.L4_ExtensionFunction;
using Day9.L567_Delegate_AnonymousMethod_lambda;
using Day9.L9_L11;
using Day9.L12_L13;
using Day9.Shared;

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

            #region L5_Delegate_L7Func_Lambda
            string[] Names = Source.SetStringArr();
            foreach (string name in Names)
            {
                Console.WriteLine("75 -- name: {0}.", name);
            }
            Console.WriteLine("Press 1 Input Start With letter, Press 2 input End with Letter.");
            string InputedNum = Console.ReadLine();

            PrintOutStringArr Print = new PrintOutStringArr();
            switch (InputedNum)
            {
                case "1":
                    Console.WriteLine("Input Start Letter: ");
                    string LetterStart = Console.ReadLine();
                    L5Delegate l5DelegateS = new L5Delegate(Names, LetterStart);
                    string[] RzNames0 = l5DelegateS.CollectNames(DelegateMethods.CheckStartwithLetter);
                    Print.PrintStrArr(RzNames0);
                    break;
                case "2":
                    Console.WriteLine("Input End Letter: ");
                    string LetterEnd = Console.ReadLine();
                    L5Delegate l5DelegateE = new L5Delegate(Names, LetterEnd);
                    string[] RzNames1 = l5DelegateE.CollectNames(DelegateMethods.CheckEndwithLetter);
                    Print.PrintStrArr(RzNames1);
                    break;
                default:
                    Console.WriteLine("This is default codition. Press Enter to continue...");
                    break;
            }

            Console.WriteLine("\nThis will display how to use delegate expression.\n");
            Console.WriteLine("Please Letter Option -- 1 for Start Letter, 2 for End Letter.");
            string InputedLo = Console.ReadLine();
            if (InputedLo == "1")
            {
                Console.WriteLine("105 -- Input Start Letter: ");
                string sl = Console.ReadLine();
                L5Delegate l5DelegateExpression = new L5Delegate(Names, sl);
                string[] RzNamesExp = l5DelegateExpression.CollectNames(delegate(string n, string s) { return n.StartsWith(s);});
                Print.PrintStrArr(RzNamesExp);
            }
            else if(InputedLo == "2") {
                Console.WriteLine("120 -- Input End Letter: ");
                string el = Console.ReadLine();
                L5Delegate l5DelegateExpression = new L5Delegate(Names, el);
                string[] RzNamesExp = l5DelegateExpression.CollectNames(delegate(string n, string l) { return n.EndsWith(l); });
                Print.PrintStrArr(RzNamesExp);
            }
            else {
                return;
            }

            Console.WriteLine("\n 122 -- This will display how to use Lambda for Delegate -- and -- Func Interface.\n");
            Console.WriteLine("Please Letter Option -- 3 for Start Letter, 4 for End Letter.");
            string NewLt = Console.ReadLine();
            if (NewLt == "3")
            {
                Console.WriteLine("127 -- Input Start Letter: ");
                string sl = Console.ReadLine();
                L7FuncNLambda L7FL = new L7FuncNLambda();
                string[] RzNamesLambda = L7FL.CollectNames(((s, l)=> s.StartsWith(l)), Names, sl);
                Print.PrintStrArr(RzNamesLambda);
            }
            else if(NewLt == "4") {
                Console.WriteLine("134 -- Input End Letter: ");
                string el = Console.ReadLine();
                L7FuncNLambda L7FL = new L7FuncNLambda();
                string[] RzNamesLambda = L7FL.CollectNames(((s, l) => s.EndsWith(l)), Names, el);
                Print.PrintStrArr(RzNamesLambda);
            }
            else {
                return;
            }

            Console.WriteLine("0 for +, 1 for -, 2 for *, 3 for /");
            string optString = Console.ReadLine();
            Console.WriteLine("Input first Number: ");
            double num0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input second Number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            L5Delegate l5DelegateOp = new L5Delegate(Names, "A");
            switch (optString)
            {
                case "0":
                    l5DelegateOp.DoCalculate(DelegateMethods.plus, num0, num1);
                    break;
                case "1":
                    l5DelegateOp.DoCalculate(DelegateMethods.minus, num0, num1);
                    break;
                case "2":
                    l5DelegateOp.DoCalculate(DelegateMethods.multiple, num0, num1);
                    break;
                case "3":
                    l5DelegateOp.DoCalculate(DelegateMethods.devide, num0, num1);
                    break;
                default:
                    Console.WriteLine("This is Calculation Default Option...");
                    break;
            }

            Console.WriteLine("\n170This time use Func<> and Lambda for delegate.");
            Console.WriteLine("0 for +, 1 for -, 2 for *, 3 for /");
            string optStr = Console.ReadLine();
            Console.WriteLine("Input first Number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input second Number: ");
            double num3 = Convert.ToDouble(Console.ReadLine());
            L7FuncNLambda L7ForCal = new L7FuncNLambda();
            switch (optStr)
            {
                case "0":
                    L7ForCal.ShowCalculateResult(((a, b) => a+b), num2, num3);
                    break;
                case "1":
                    L7ForCal.ShowCalculateResult(((a, b) => a-b), num2, num3);
                    break;
                case "2":
                    L7ForCal.ShowCalculateResult(((a, b) => a*b), num2, num3);
                    break;
                case "3":
                    L7ForCal.ShowCalculateResult(((a, b) => a/b), num2, num3);
                    break;
                default:
                    Console.WriteLine("This is Calculation Default Option...");
                    break;
            }

            Console.WriteLine("\nThis is multiple cast Delegate.\n");
            Console.WriteLine("Input a string like: abcdefg");
            string aStr = Console.ReadLine();
            
            StringAndMultipleCastDelegate.UpperCaseString ShowUpperCase = DelegateMethods.FirstUpper;
            ShowUpperCase += DelegateMethods.LastUpper;
            ShowUpperCase += DelegateMethods.AllUpper;
            ShowUpperCase(aStr);

            #endregion

            #region L9-L11
            L9Linq LinqCountries = new L9Linq();
            LinqCountries.ShowAllCountries();

            L11LinqRetrunObj odObj = new L11LinqRetrunObj();
            odObj.ShowOrderDates();
            #endregion

            #region L12_L13
            L12_WhereClause wc = new L12_WhereClause();
            wc.LinqQueryWhere();
            wc.MethodSyntaxWhere();
            wc.OpDataCrossTablesNLevels();
            L13_BuildInFunction bf = new L13_BuildInFunction();
            bf.ShowBuildInFunction();
            #endregion

            Console.ReadLine();


        }
    }
}
