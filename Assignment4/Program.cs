using Assignment4.Contexts;
using Assignment4.Helpers;
using Assignment4.Models;
using Assignment4.Ops;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var _context =  new AppDbContext();
            if (!await _context.Branches.AnyAsync()) 
            {
                _context.Branches.AddRange(
                     new Branch()
                     {
                         Address = "Bikini bottom st 13",
                         Name = "Krusty Krab",
                         PhoneNumber = "010",
                         BranchManager = new Manager() { Email = "spongbob@gmail.com", FullName = "Spongbob squre pants", HireDate = new DateOnly(), ManagerId = 1, ManagerPhoneNumber = "011" }
                     },
                    new Branch()
                    {
                        Address = "NoIdea st 67",
                        Name = "Samurai Jack",
                        PhoneNumber = "206-826-4480",
                        BranchManager = new Manager() { Email = "salahmosh@gmail.com", FullName = "Sal el salo", HireDate = new DateOnly(), ManagerId = 2, ManagerPhoneNumber = "206-902-1100" }
                    }
                );

                await _context.SaveChangesAsync();
            }

            #region Showing menu options
            HelperClass.MenuOptions();
            int option = HelperClass.GetInt();
            #endregion

            #region Run the code based on the option
            if (option == 1)
                await AddCx.Run();
            else if (option == 2)
                await AddAccount.Run();
            else if (option == 3)
                await UpdateAccState.Run();
            #endregion
        }
    }
}
