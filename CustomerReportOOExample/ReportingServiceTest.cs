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
    public class ReportingServiceTest
    {
        [Test]
        public void RunCustomerReportBatchShouldSendReports()
        {
            // Arrange
            var customerDataMock = new Mock<ICustomerData>();
            var emailerMock = new Mock<IEmailer>();

            var customerMock = new Mock<ICustomer>();

            var reportMock = new Mock<IReport>();

            var expectedEmail = "fist@sea.com";
            var expectedReportBody = "the report body";

            reportMock.SetupGet(x => x.ToAddress)
                .Returns(expectedEmail);
            reportMock.SetupGet(x => x.Body)
                .Returns(expectedReportBody);

            customerMock.Setup(x => x.CreateReport())
                .Returns(reportMock.Object);

            customerDataMock.Setup(x => x.GetCustomersForCustomerReport())
                .Returns(new[] { customerMock.Object });

            var sut = new ReportingService(
                customerDataMock.Object,
                emailerMock.Object);

            // Act
            sut.RunCustomerReportBatch();

            // Assert
            emailerMock.Verify(x => x.Send(expectedEmail, expectedReportBody));
        }
    }
}
