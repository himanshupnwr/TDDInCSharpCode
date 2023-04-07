using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderPattern
{
    [TestClass]
    public  class BadPhoneServiceTests
    {
        [TestMethod]
        public void Test()
        {
            var gpsMock = new GpsMock();
            gpsMock.SetSteps(5000);

            var service = new PhoneService(new ConnectionMock(), gpsMock, null);

            StepStatus met = service.NumberOfStepsMet();
            Assert.AreEqual(met,StepStatus.Met);
        }

        private PhoneService GetWithConnection(IConnection connection)
        {
            return new PhoneService(connection, null, null);
        }

        private PhoneService GetWithGpsAndConnection(IConnection connection, IGps gps)
        {
            return new PhoneService(connection, gps, null);
        }

        private PhoneService GetWithGpsAndConnectionAndSensor(IConnection connection, IGps gps, ISpeedSensor speedSensor)
        {
            return new PhoneService(connection, gps, speedSensor);
        }
    }
}
