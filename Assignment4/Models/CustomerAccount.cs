using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    internal class CustomerAccount
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AccountNumber { get; set; }
        public Account Account { get; set; }
        public string OwnershipType { get; set; }
        public string AccountStatus { get; set; }
        public DateTime OwnerShipStartDate { get; set; }

    }
}
