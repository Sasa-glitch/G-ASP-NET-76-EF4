using Assignment4.Contexts;
using Assignment4.Helpers;
using Assignment4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Ops
{
    internal static class AddCx
    {
        public static Customer GetCxData()
        {
            Customer theCx;
            Console.WriteLine("--- Add New Customer ---");
            Console.WriteLine("Full Name       : ");
            string fullName = Console.ReadLine();
            Console.WriteLine("National ID     : ");
            string nId = Console.ReadLine();
            Console.WriteLine("Date of Birth   : (Year-Month-Day)");
            DateOnly DOB = HelperClass.GetDate();
            Console.WriteLine("Email           : ");
            string Email = Console.ReadLine();
            Console.WriteLine("Phone           : ");
            string phone = Console.ReadLine();
            Console.WriteLine("Address         : ");
            string address = Console.ReadLine();
            Console.WriteLine("Customer Type   : ");
            Console.WriteLine("    1) Individual");
            Console.WriteLine("    2) Business");
            Console.WriteLine("Choice: ");
            int cxType;
            while (true)
            {
                cxType = HelperClass.GetInt();
                if (cxType == 1 || cxType == 2)
                    break;
                else
                    Console.WriteLine("Man it isn't that hard JUST CHOICE 1 OR 2 OK!");
            }
            

            theCx = new Customer()
            {
                Address = address,
                CustomerType = cxType,
                DateOfBirth = DOB,
                FullName = fullName,
                Email = Email,
                NationalId = nId,
                PhoneNumber = phone
            };
            return theCx;

        }
        public static async Task InsertCx(Customer theCx)
        {
            using var _Context = new AppDbContext();
            _Context.Customers.Add(theCx);
            int state = await _Context.SaveChangesAsync();
            if (state == 1)
                Console.WriteLine($"Customer created successfully. CustomerId = {theCx.Id}");
            else
                Console.WriteLine("The customer wasn't added");

        }
        public static async Task Run()
        {
            Customer customer = GetCxData();
            await InsertCx(customer);
        }

    }
}
