using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public interface IReport
    {
        void SendAsEmail(IEmailer emailer);
    }

    public class Report : IReport
    {
        private string ToAddress { get; set; }
        private string Body { get; set; }

        public Report(string toAddress, string body)
        {
            ToAddress = toAddress;
            Body = body;
        }

        public void SendAsEmail(IEmailer emailer)
        {
            emailer.Send(ToAddress, Body);
        }
    }
}
