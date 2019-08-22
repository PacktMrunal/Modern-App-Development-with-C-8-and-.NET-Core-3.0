using Section1Video5.Exceptions;
using System;

namespace Section1Video5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //throw new Exception("Whatever");
                //throw new HttpException(404);
                //throw new HttpException(500);
                throw new HttpException(503);
            }
            catch (Exception ex)
            {
                IReporter reporter = new Reporter();
                Console.WriteLine(reporter.Report(ex, "Error in main method", SecurityLevel.Error));
            }
        }
    }
}
