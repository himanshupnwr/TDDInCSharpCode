namespace TddMocks
{

    //Testing nomenclature
    //Dummy data - Dummy is a test double which returns values which are either null in case if returning a reference type
    //or close to zero in case of structures

    //Dummies don't do inside of a method which are not supposed to return anything

    //Stub - is a dummy which is set so that it returns predefined constant values from methods called on the object 
    //which that stub replaces. Use stubs to drive the execution flows through specific pathways.
    //A stub is a substitute of a dependency in the system under test and it allows it to compile

    //Spy - spy is a stub which saves some information about the calls made on the spy. To verify if correct calls are made.

    //It allows to verify what argument values were passed in the methods, how many time any methods were called, in what order
    //the methods were called

    //Mock - mock is a spy but mocks contains assertions inside itself, so mock can cause the failure of a test.

    //Fake - Fake is a test double which simulates the behaviour of a real dependency as close to reality as possible.

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Customer
    {
        private IDbGateway _dbGateway;
        private ILogger _logger;

        public Customer(IDbGateway dbGateway, ILogger logger)
        {
            _dbGateway = dbGateway;
            _logger = logger;
        }

        public decimal CalculateWage(int id)
        {
            WorkingStatistics ws = null;
            try
            {
                ws = _dbGateway.GetWorkingStatistics(id);
            }
            catch (Exception exception)
            {
                return 0;
            }
            
            decimal wage;
            if (ws.PayHourly)
            {
                wage = ws.WorkingHours * ws.HourSalary;
            }
            else
            {
                wage = ws.MonthSalary;
            }

            _logger.Info($"CustomerId = {id}, wage = {wage}");

            return wage;
        }

    }

    public record WorkingStatistics
    {
        public bool PayHourly;
        private int _workingHours;
        private int _hourSalary;
        private decimal _monthSalary;

        public int WorkingHours
        {
            get => _workingHours;
            set => _workingHours = value;
        }

        public int HourSalary
        {
            get => _hourSalary;
            set => _hourSalary = value;
        }

        public decimal MonthSalary
        {
            get => _monthSalary;
            set => _monthSalary = value;
        }
    }

    public interface IDbGateway
    {
        WorkingStatistics GetWorkingStatistics(int id);
    }

    public class DbGateway : IDbGateway
    {
        public WorkingStatistics GetWorkingStatistics(int id)
        {
            throw new NotImplementedException();
        }
    }

    public interface ILogger
    {
        void Info(string v);
    }

    public class Logger : ILogger
    {
        public void Info(string v)
        {
            File.WriteAllText(@"C:\temp:\log.txt", v);
        }
    }
}