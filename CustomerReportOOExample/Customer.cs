using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public interface ICustomer
    {
        IReport CreateReport();
    }

    public class Customer : ICustomer
    {
        private string Email { get; set; }

        public Customer(string email)
        {
            Email = email;
        }

        public IReport CreateReport()
        {
            return new Report(Email, "This is the report for {customer.Email}!");
        }
    }
}
