using Assignment4.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Ops
{
    internal static class GetCxDetails
    {
        public static void Run()
        {
            using var _Context = new AppDbContext();
            var allCx = _Context.Customers.Include(e => e.AccountsCustomerHave).ThenInclude(e => e.Account).ThenInclude(e => e.AccountsBranch).ToList();
            foreach(var cx in allCx)
            {
                string cxType = cx.CustomerType == 1 ? "Individual" : cx.CustomerType == 2 ? "Business" : "Unknown";
                Console.WriteLine($"#{cx.Id} {cx.FullName} ({cxType}):");
                if (cx.AccountsCustomerHave.Count == 0)
                    Console.WriteLine("(no accounts)");
                else
                {
                    foreach (var account in cx.AccountsCustomerHave)
                    {
                        Console.WriteLine($"      Account Number: {account.AccountNumber}, Current Balance: {account.Account.CurrentBalance}, Owndership Type: {account.OwnershipType}, Account Status: {account.AccountStatus}, @ {account.Account.AccountsBranch.Name} Branch");
                    }
                }
                
            }
        }
    }
}
