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
    public class CustomerReportTest
    {
        [Test]
        public void RunCustomerReportBatchShouldSendReports()
        {
            // Arrange
            var customerDataMock = new Mock<ICustomerData>();
            var reportBuilderMock = new Mock<IReportBuilder>();
            var emailerMock = new Mock<IEmailer>();

            var expectedCustomer = new Customer("fist@sea.com");
            var expectedReportBody = "the report body";

            customerDataMock.Setup(x => x.GetCustomersForCustomerReport())
                .Returns(new[] { expectedCustomer });

            reportBuilderMock.Setup(x => x.CreateCustomerReport(expectedCustomer))
                .Returns(new Report(expectedCustomer.Email, expectedReportBody));

            var sut = new ReportingService(
                customerDataMock.Object,
                reportBuilderMock.Object,
                emailerMock.Object);

            // Act
            sut.RunCustomerReportBatch();

            // Assert
            emailerMock.Verify(x => x.Send(expectedCustomer.Email, expectedReportBody));
        }
    }
}
