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

            var customerMock = new Mock<ICustomer>();

            customerMock.SetupGet(x => x.Email)
                .Returns("fist@sea.com");
            var expectedReportBody = "the report body";

            customerDataMock.Setup(x => x.GetCustomersForCustomerReport())
                .Returns(new[] { customerMock.Object });

            reportBuilderMock.Setup(x => x.CreateCustomerReport(customerMock.Object))
                .Returns(new Report(customerMock.Object.Email, expectedReportBody));

            var sut = new ReportingService(
                customerDataMock.Object,
                reportBuilderMock.Object,
                emailerMock.Object);

            // Act
            sut.RunCustomerReportBatch();

            // Assert
            emailerMock.Verify(x => x.Send(customerMock.Object.Email, expectedReportBody));
        }
    }
}
