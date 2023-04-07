using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddMocks;

namespace TddMocksTest.TestDoubles
{
    internal class DbGatewaySpy: IDbGateway
    {
        private WorkingStatistics _workingStatistics;
        public int Id { get; private set; }

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            Id = id;
            return _workingStatistics;
        }

        public void SetWorkingStatistics(WorkingStatistics workingStatistics)
        {
            _workingStatistics = workingStatistics;
        }
    }
}
