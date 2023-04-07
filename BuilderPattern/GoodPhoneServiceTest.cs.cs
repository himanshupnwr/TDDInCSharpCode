using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderPattern
{
    [TestClass]
    internal class GoodPhoneServiceTest
    {
        [TestMethod]
        public void Test()
        {
            var gpsMock = new GpsMock();
            gpsMock.SetSteps(5000);

            var service = new PhoneServiceBuilder().WithConnection(new ConnectionMock()).WithGps(gpsMock).Build();

            StepStatus met = service.NumberOfStepsMet();
            Assert.AreEqual(StepStatus.Met, met);
        }
    }
}
