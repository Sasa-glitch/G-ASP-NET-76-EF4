using Assignment4.Contexts;
using Assignment4.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Ops
{
    internal static class UpdateAccState
    {
        public static async Task Run()
        {
            using var _Context = new AppDbContext();
            Console.WriteLine("--- Update Account Status ---");
            Console.WriteLine("Account Number : ");
            int accNum;
            while (true) 
            {
                accNum = HelperClass.GetInt();
                bool accExist = _Context.Accounts.Any(e => e.AccountNumber == accNum);
                if (accExist)
                    break;
                else
                    Console.WriteLine($"There is no account under this number {accNum}! Try again!!");
            }
            Console.WriteLine("Customer Id    : ");
            int cxId;
            while (true)
            {
                cxId = HelperClass.GetInt();
                bool cxExist = _Context.CustomersAccount.Any(e => e.CustomerId == cxId && e.AccountNumber == accNum);
                if (cxExist)
                    break;
                else
                    Console.WriteLine($"There is no customer under this Id {cxId} in this account {accNum}! Try again!");
            }
            Console.WriteLine("New Status : ");
            Console.WriteLine("  1) Active");
            Console.WriteLine("  2) Closed");
            Console.WriteLine(" Choice: ");
            int state;
            while (true)
            {
                state = HelperClass.GetInt();
                if (state == 1 || state == 2)
                    break;
                else
                    Console.WriteLine("Isn't it obvious there is only two options? Can you do it right this time?");
            }
            string daState = state == 0 ? "Active" : "Closed";
            var daAcc = await _Context.CustomersAccount.FirstOrDefaultAsync(e => e.AccountNumber == accNum && e.CustomerId == cxId);
            if (daAcc == null)
            {
                Console.WriteLine("Failed to retrive the account!!! :(");
                return;
            }
            daAcc.AccountStatus = daState;
            int processStatus = await _Context.SaveChangesAsync();
            if (processStatus == 1)
                Console.WriteLine($"Status was sucessefully updated to {daState}!");
            else
                Console.WriteLine($"Status wasn't updated to {daState}! Error happened!");


        }
    }
}
