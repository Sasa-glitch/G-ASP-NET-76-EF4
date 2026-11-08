using Assignment4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(e => e.AccountsBranch)
                .WithMany(e => e.Accounts)
                .HasForeignKey(e => e.AccountsBranchId);
            builder.HasKey(e => e.AccountNumber);
        }
    }
}
