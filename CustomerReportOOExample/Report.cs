using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public class Report
    {
        public string ToAddress { get; private set; }
        public string Body { get; private set; }

        public Report(string toAddress, string body)
        {
            ToAddress = toAddress;
            Body = body;
        }
    }
}
