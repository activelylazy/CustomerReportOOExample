using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public class ReportingService
    {
        public ReportingService(ICustomerData customerData, IEmailer emailer)
        {
            CustomerData = customerData;
            Emailer = emailer;
        }

        public ICustomerData CustomerData { get; private set; }
        public IEmailer Emailer { get; private set; }

        public void RunCustomerReportBatch()
        {
            var customers = CustomerData.GetCustomersForCustomerReport();

            foreach (var customer in customers)
            {
                var report = customer.CreateReport();
                report.SendAsEmail(Emailer);
            }
        }
    }
}
