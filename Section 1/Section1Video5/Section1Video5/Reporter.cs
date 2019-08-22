using Section1Video5.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Section1Video5
{
    public class Reporter : IReporter
    {
        public string Report(Exception ex, string description, SecurityLevel level)
        {
            if (ex is HttpException)
            {
                HttpException httpEx = ex as HttpException;
                return httpEx switch
                {
                    { StatusCode: 404 } => $"{description}: Not Found Error",
                    { StatusCode: 400 } => $"{description}: Bad Request",
                    { StatusCode: 500 } => $"{description}: Internal Server Error",
                    _ => $"{description}: Http Error"
                };
            }
            else
            {
                return $"{description}: Oops something went wrong";
            }
        }
    }
}
