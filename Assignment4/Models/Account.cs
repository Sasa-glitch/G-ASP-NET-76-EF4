using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    internal class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public string AccountType { get; set; }
        public DateTime OpeningDate { get; set; }
        public Branch AccountsBranch { get; set; }
        public int AccountsBranchId { get; set; }
        public Transaction[] Transactions { get; set; }
        public CustomerAccount[] CustomersHavingTheAccount { get; set; }
    }
}
