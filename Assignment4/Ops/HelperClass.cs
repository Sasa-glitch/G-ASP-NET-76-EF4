using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Helpers
{
    internal class HelperClass
    {
        public static int GetInt()
        {
            string input = Console.ReadLine();
            int returned;
            while (true)
            {
                bool didParse = int.TryParse(input, out returned);
                if (didParse) { break; }
                Console.WriteLine("Invalid Input Enter Again");
                input = Console.ReadLine();
            }
            return returned;
        }
        public static DateOnly GetDate()
        {
            string input = Console.ReadLine();
            DateOnly returned;
            while (true)
            {
                bool didParse = DateOnly.TryParse(input, out returned);
                if (didParse) { break; }
                Console.WriteLine("Invalid Input Enter Again");
                input = Console.ReadLine();
            }
            return returned;
        }
        public static void DrawLine()
        {
            Console.WriteLine("====================================");
        }
        public static void DrawThinLine()
        {
            Console.WriteLine("------------------------------------");
        }
        public static void MenuOptions()
        {
            HelperClass.DrawLine();
            Console.WriteLine("National Bank - Management");
            HelperClass.DrawLine();
            Console.WriteLine("1) Add a new Customer");
            Console.WriteLine("2) Open a new Account for a Customer");
            Console.WriteLine("3) Update Account Status (Active / Closed)");
            Console.WriteLine("4) Remove an Account from a Customer");
            Console.WriteLine("5) List all Customers (with accounts)");
            Console.WriteLine("0) Exit");
            HelperClass.DrawThinLine();
            Console.WriteLine("Enter choice:");
        }
    }
}
