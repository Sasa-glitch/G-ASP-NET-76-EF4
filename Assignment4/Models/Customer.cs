using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerType { get; set; }
        public string NationalId { get; set; }
        public CustomerAccount[] AccountsCustomerHave {  get; set; }
    }
}
