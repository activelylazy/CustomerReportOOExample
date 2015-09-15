using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public class Customer
    {
        public string Email { get; private set; }

        public Customer(string email)
        {
            Email = email;
        }
    }
}
