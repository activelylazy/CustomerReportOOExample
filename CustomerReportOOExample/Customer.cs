using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public interface ICustomer
    {
        string Email { get; }
    }

    public class Customer : ICustomer
    {
        public string Email { get; private set; }

        public Customer(string email)
        {
            Email = email;
        }
    }
}
