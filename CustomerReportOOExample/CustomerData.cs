using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetCustomersForCustomerReport();
    }

    public class CustomerData : ICustomerData
    {
        public IEnumerable<Customer> GetCustomersForCustomerReport()
        {
            // pretend to do data access
            yield return new Customer("mike@mikelair.com");
            yield return new Customer("leo@leofort.com");
            yield return new Customer("yuna@yunacastle.com");
        }
    }
}
