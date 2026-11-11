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
    internal class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(e => new { e.AccountNumber, e.CustomerId });
            builder.HasOne(e => e.Account)
                .WithMany(e => e.CustomersHavingTheAccount)
                .HasForeignKey(e => e.AccountNumber);
            builder.HasOne(e => e.Customer)
                .WithMany(e => e.AccountsCustomerHave)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
