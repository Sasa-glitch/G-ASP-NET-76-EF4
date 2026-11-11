using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    internal class Branch
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Manager BranchManager { get; set; }

        public List<Account> Accounts { get; set; } = new();
    }
}
