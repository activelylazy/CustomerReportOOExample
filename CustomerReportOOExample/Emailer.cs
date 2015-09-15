using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public interface IEmailer
    {
        void Send(string toAddress, string body);
    }

    public class Emailer : IEmailer
    {
        public void Send(string toAddress, string body)
        {
            // pretend to send an email here
            Console.Out.WriteLine("Sent Email to: {0}, Body: '{1}'", toAddress, body);
        }
    }

}
