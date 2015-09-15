using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReportOOExample
{
    public class Report
    {
        public string Recipient { get; private set; }
        public string Text { get; private set; }

        public Report(string recipient, string text)
        {
            Recipient = recipient;
            Text = text;
        }
    }
}
