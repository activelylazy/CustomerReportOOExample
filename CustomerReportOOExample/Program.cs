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

    public interface IReportBuilder
    {
        Report CreateCustomerReport(Customer customer);
    }

    public interface IEmailer
    {
        void Send(string toAddress, string body);
    }

    public class Customer
    {
        public string Email { get; private set; }

        public Customer(string email)
        {
            Email = email;
        }
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
    
    public class ReportBuilder : IReportBuilder
    {
        public Report CreateCustomerReport(Customer customer)
        {
            return new Report(customer.Email, "This is the report for {customer.Email}!");
        }
    }
    
    public class Emailer : IEmailer
    {
        public void Send(string toAddress, string body)
        {
            // pretend to send an email here
            Console.Out.WriteLine("Sent Email to: {0}, Body: '{1}'", toAddress, body);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
