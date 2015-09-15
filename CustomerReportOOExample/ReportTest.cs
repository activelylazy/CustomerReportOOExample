using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace CustomerReportOOExample
{
    [TestFixture]
    public class ReportTest
    {
        [Test]
        public void SendAsEmail_EmailsReport()
        {
            // Arrange
            var emailerMock = new Mock<IEmailer>();
            var toAddress = "some@example.com";
            var body = "the report body";

            var report = new Report(toAddress, body);

            // Act
            report.SendAsEmail(emailerMock.Object);

            // Assert
            emailerMock.Verify(x => x.Send(toAddress, body));
        }
    }
}
