using Section1Video4.Exceptions;
using System;

namespace Section1Video4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //throw new Exception("Whatever");
                //throw new HttpException(404);
                throw new HttpException(500);
            }
            catch(Exception ex)
            {
                IReporter reporter = new Reporter();
                reporter.Report(ex, "Error in main method", SecurityLevel.Error);
            }
        }
    }
}
