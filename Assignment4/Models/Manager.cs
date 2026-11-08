using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    internal class Manager
    {
        public int ManagerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ManagerPhoneNumber { get; set; }
        public DateOnly HireDate { get; set; }
    }
}
