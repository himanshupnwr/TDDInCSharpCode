using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddMocks;

namespace TddMocksTest.TestDoubles
{
    internal class DbGatewayFake : IDbGateway
    {
        private Dictionary<int, WorkingStatistics> _store = new Dictionary<int, WorkingStatistics>()
        {
            { 1, new WorkingStatistics() { PayHourly = true, WorkingHours = 5, HourSalary = 10 } },
            { 2, new WorkingStatistics() { PayHourly = false, MonthSalary = 500 } },
            { 3, new WorkingStatistics() { PayHourly = true, WorkingHours = 5, HourSalary = 10 } }
        };
        public WorkingStatistics GetWorkingStatistics(int id)
        {
            return _store[id];
        }
    }
}
