using Section1Video4.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Section1Video4
{
    public class Reporter : IReporter
    {
        public void Report(Exception ex, string description, SecurityLevel level)
        {
            if (ex is HttpException { StatusCode: 404})
            {
                Console.WriteLine($"{description}: NOT FOUND ERROR");
            }
            else if(ex is HttpException { StatusCode: 500})
            {
                Console.WriteLine($"{description}: INTERNAL SERVER ERROR");
            }
            else
            {
                Console.WriteLine($"{description}: Oops something went wrong");
            }
        }
    }
}
