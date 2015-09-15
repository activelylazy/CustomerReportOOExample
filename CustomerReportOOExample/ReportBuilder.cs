using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public interface IReportBuilder
    {
        IReport CreateCustomerReport(ICustomer customer);
    }

    public class ReportBuilder : IReportBuilder
    {
        public IReport CreateCustomerReport(ICustomer customer)
        {
            return new Report(customer.Email, "This is the report for {customer.Email}!");
        }
    }
}
