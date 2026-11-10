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
    internal static class AddAccount
    {
        // since my archtiecture is different I will follow a different approache than in the pictures
        public static Account GetAccData()
        {
            using var _Context = new AppDbContext();
            Console.WriteLine("--- Open New Account ---");
            //Console.WriteLine("Account Number : "); it is identity
            Console.WriteLine("Account Type     : ");
            Console.WriteLine(" 1) Savings");
            Console.WriteLine(" 2) Current");
            Console.WriteLine(" 3) Business");
            Console.WriteLine("Choice: ");
            int accountType = HelperClass.GetInt();
            Console.WriteLine("Branch Code      : ");
            int branchCode;
            while (true)
            {
                branchCode = HelperClass.GetInt();

                bool willBreak = _Context.Branches.Any(e => e.Code == branchCode);
                if (willBreak)
                    break;
                else
                    Console.WriteLine("Branch doesn't exist try again...");
            }
            

            return new Account() { AccountType = accountType, AccountsBranchId = branchCode, CurrentBalance = 0, OpeningDate = DateTime.Now };

        }
        public static async Task<int> InsertAccount(Account account)
        {
            using var _Context = new AppDbContext();
            _Context.Accounts.Add(account);
            int state = await _Context.SaveChangesAsync();

            if (state == 1)
            {
                Console.WriteLine($"Account was created successfully. Account Number = {account.AccountNumber}");
                return account.AccountNumber;
            }
            else
            {
                Console.WriteLine("Any error happened account wasn't added");
                return -1;
            }
        }
        public static async Task AttachAccountWithCx(int accNum)
        {
            using var _Context = new AppDbContext();

            if (accNum == -1)
            {
                Console.WriteLine("Can't attach the account with a customer because it wasn't added");
                return;
            }
            Console.WriteLine("Customer Id      : ");
            int cxId;
            while (true)
            {
                cxId = HelperClass.GetInt();

                bool willBreak = _Context.Customers.Any(e => e.Id == cxId);
                if (willBreak)
                    break;
                else
                    Console.WriteLine("Customer doesn't exist try again...");
            }
            Console.WriteLine("Ownership Role   : ");
            Console.WriteLine(" 1) Primary");
            Console.WriteLine(" 2) CoHolder");
            Console.WriteLine("Choice: ");
            int ownRole;
            while (true)
            {
                ownRole = HelperClass.GetInt();
                if (ownRole == 0 || ownRole == 1)
                    break;
                else
                    Console.WriteLine("Just choice 1 or 2 please... stop being like this!!!");
            }

            string ownerShip = ownRole == 1 ? "Primary" : "CoHolder";

            CustomerAccount linkedAcc = new CustomerAccount() { CustomerId = cxId, OwnerShipStartDate = DateTime.Now, OwnershipType = ownerShip, AccountNumber = accNum, AccountStatus = "Active" };
            _Context.CustomersAccount.Add(linkedAcc);
            int state = await _Context.SaveChangesAsync();
            if (state == 1)
                Console.WriteLine($"Account '{accNum}' was created and linked to customer {cxId} as {ownerShip} owner..");
            
        }
        public static async Task Run()
        {
            Account daAcc = GetAccData();
            int accNum = await InsertAccount( daAcc );
            await AttachAccountWithCx(accNum);
        }
    }
}
