using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public interface IReportBuilder
    {
        Report CreateCustomerReport(Customer customer);
    }

    public class ReportBuilder : IReportBuilder
    {
        public Report CreateCustomerReport(Customer customer)
        {
            return new Report(customer.Email, "This is the report for {customer.Email}!");
        }
    }
}
