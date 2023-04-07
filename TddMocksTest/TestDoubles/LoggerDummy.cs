using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddMocks;

namespace TddMocksTest.TestDoubles
{
    public class LoggerDummy : ILogger
    {
        public void Info(string v)
        {
            //do nothing
        }
    }
}
