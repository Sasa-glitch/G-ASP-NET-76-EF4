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
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(e => e.Account)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.AccountId);
            builder.HasKey(e => e.TransactionNumber);
        }
    }
}
