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
            foreach (var report in CustomerData.GetCustomersForCustomerReport()
                                        .Select(c => c.CreateReport()))
            {
                report.SendAsEmail(Emailer);
            }
        }
    }
}
