using Assignment4.Contexts;
using Assignment4.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Assignment4.Ops
{
    internal static class RemoveCxAccLink
    {
        public static async Task Run()
        {
            var _Context = new AppDbContext();
            Console.WriteLine("--- Remove Account From Customer ---");
            Console.WriteLine("Account Number :");
            int accNum;
            while (true)
            {
                accNum = HelperClass.GetInt();
                bool accExist = await _Context.Accounts.AnyAsync(e => e.AccountNumber == accNum);
                if (accExist)
                    break;
                else
                    Console.WriteLine("There is no account under this num try again!");
            }
            Console.WriteLine("Customer Id    :");
            int cxId;
            while (true)
            {
                cxId = HelperClass.GetInt();
                bool cxExist = await _Context.CustomersAccount.AnyAsync(e => e.AccountNumber == accNum && e.CustomerId == cxId);
                if (cxExist)
                    break;
                else
                    Console.WriteLine($"There is no customer under id {cxId} related to account number {accNum}! Try again!!!");
            }
            var link = await _Context.CustomersAccount
    .           FirstOrDefaultAsync(ca => ca.CustomerId == cxId && ca.AccountNumber == accNum);
            if (link == null)
            {
                Console.WriteLine("AN issue happened retriving the link!");
                return;
            }
            _Context.CustomersAccount.Remove(link);
            int result = await _Context.SaveChangesAsync();
            if (result == 1)
                Console.WriteLine("Ownership link deleted! ");
            bool remAccCount = await _Context.CustomersAccount.AnyAsync(e => e.AccountNumber == accNum);
            if (remAccCount)
            {
                await _Context.Accounts.Where(e => e.AccountNumber == accNum).ExecuteDeleteAsync();
                int state = await _Context.SaveChangesAsync();
                if (state == 1)
                    Console.WriteLine($"That was the last owner account '{accNum}' was also removed.");
            }
        }
    }
}
