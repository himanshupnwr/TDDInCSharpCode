using Castle.Core.Resource;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System.Reflection.Metadata;
using TddMocks;
using TddMocksTest.TestDoubles;

namespace TddMocksTest
{
    [TestClass]
    public class CustomerTestWithMockingFramework
    {
        [TestMethod]
        public void CalculateWage_HourlyPayed_ReturnsCorrectWage()
        {
            var gateway = Substitute.For<IDbGateway>();
            var workingStatistics = new WorkingStatistics() { PayHourly = true, HourSalary = 100, WorkingHours = 10 };

            const int anyId = 1;
            gateway.GetWorkingStatistics(Arg.Any<int>()).ReturnsForAnyArgs(workingStatistics);

            const decimal expectedWage = 100 * 10;
            var customerInfo = new Customer(gateway, Substitute.For<ILogger>());
            decimal actDecimal = customerInfo.CalculateWage(Arg.Any<int>());

            Assert.AreEqual(actDecimal, expectedWage);
        }

        [TestMethod]
        public void CalculateWage_PassesCorrectId()
        {
            const int id = 1;
            var gateway = Substitute.For<IDbGateway>();
            gateway.GetWorkingStatistics(id).ReturnsForAnyArgs(new WorkingStatistics());

            var customerInfo = new Customer(gateway, Substitute.For<ILogger>());
            decimal actDecimal = customerInfo.CalculateWage(id);

            gateway.Received().GetWorkingStatistics(1);
        }


        [TestMethod]
        public void CalculateWage_ThrowsException_ReturnsZero()
        {
            var gateway = Substitute.For<IDbGateway>();
            gateway.GetWorkingStatistics(Arg.Any<int>()).Throws(new InvalidOperationException());
            
            var customerInfo = new Customer(gateway, Substitute.For<ILogger>());
            decimal actDecimal = customerInfo.CalculateWage(Arg.Any<int>());

            Assert.AreEqual(actDecimal, 0);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateWage_HourlyPaid_ReturnsCorrectWages()
        {
            //Setup dependency
            DbGatewayStub gatewayStub = new DbGatewayStub();
            gatewayStub.SetWorkingStatistics(new WorkingStatistics()
                { PayHourly = true, HourSalary = 100, WorkingHours = 10 });

            //Setup
            var customer = new Customer(gatewayStub, new LoggerDummy());

            //Act
            const int anyId = 1;
            decimal actDecimal = customer.CalculateWage(anyId);
            const decimal expectedWage = 100 * 10;

            //Assert
            Assert.AreEqual(actDecimal, expectedWage);
        }

        //Interaction Unit test for dbgateway spy
        [TestMethod]
        public void CalculateWage_PassesCorrectId()
        {
            const int id = 1;
            var gatewaySpy = new DbGatewaySpy();

            var customer = new Customer(gatewaySpy, new LoggerDummy());

            gatewaySpy.SetWorkingStatistics(new WorkingStatistics()
                { PayHourly = true, HourSalary = 100, WorkingHours = 10 });

            customer.CalculateWage(id);

            Assert.AreEqual(1, gatewaySpy.Id);
        }

        [TestMethod]
        public void CalulateWage_PassCorrectIdAgain()
        {
            const int id = 1;
            var gatewayMock = new DbGatewayMock();

            var customer = new Customer(gatewayMock, new LoggerDummy());

            gatewayMock.SetWorkingStatistics(new WorkingStatistics());

            customer.CalculateWage(id);

            Assert.IsTrue(gatewayMock.VerifyCalledWithProperId(id));
        }
    }
}