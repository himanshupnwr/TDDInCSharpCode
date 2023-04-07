using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddMocks;

namespace TddMocksTest.TestDoubles
{
    public class DbGatewayStub : IDbGateway
    {
        private WorkingStatistics _workingStatistics;
        public WorkingStatistics GetWorkingStatistics(int id)
        {
            return _workingStatistics;
        }
        public WorkingStatistics SetWorkingStatistics(WorkingStatistics workingStatistics)
        {
            return _workingStatistics = workingStatistics;
        }

    }
}
