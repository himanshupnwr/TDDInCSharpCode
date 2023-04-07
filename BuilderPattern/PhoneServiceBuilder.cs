using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class PhoneServiceBuilder
    {
        private IConnection _connection;
        private IGps _gps;
        private ISpeedSensor _speedSensor;

        public PhoneServiceBuilder WithConnection(IConnection connection)
        {
            this._connection = connection;
            return this;
        }

        public PhoneServiceBuilder WithGps(IGps gps)
        {
            this._gps = gps;
            return this;
        }

        public PhoneServiceBuilder WithSpeedSensor(ISpeedSensor speedSensor)
        {
            this._speedSensor = speedSensor;
            return this;
        }

        public PhoneService Build()
        {
            return new PhoneService(_connection, _gps, _speedSensor);
        }
    }
}
