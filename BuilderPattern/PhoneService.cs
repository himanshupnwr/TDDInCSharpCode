using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class PhoneService
    {
        private IConnection _connection;
        private IGps gps;
        private ISpeedSensor _speedSensor;

        public PhoneService(IConnection connection, IGps gps, ISpeedSensor speedSensor)
        {
            _connection = connection;
            this.gps = gps;
            _speedSensor = speedSensor;
        }

        public StepStatus NumberOfStepsMet()
        {
            _connection.Connect();
            int steps = gps.GetSteps();

            const int dailyRequirement = 5000;
            if (steps >= dailyRequirement)
            {
                return StepStatus.Met;
            }

            if (dailyRequirement - steps <= 100)
            {
                return StepStatus.AlmostMet;
            }

            return StepStatus.NotEvenCloser;
        }
    }
}
