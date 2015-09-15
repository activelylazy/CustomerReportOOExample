using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public class ReportingService
    {
        public ReportingService(ICustomerData customerData, IReportBuilder reportBuilder, IEmailer emailer)
        {
            CustomerData = customerData;
            ReportBuilder = reportBuilder;
            Emailer = emailer;
        }

        public ICustomerData CustomerData { get; private set; }
        public IReportBuilder ReportBuilder { get; private set; }
        public IEmailer Emailer { get; private set; }

        public void RunCustomerReportBatch()
        {
            var customers = CustomerData.GetCustomersForCustomerReport();

            foreach (var customer in customers)
            {
                var report = ReportBuilder.CreateCustomerReport(customer);
                Emailer.Send(report.ToAddress, report.Body);
            }
        }
    }
}
