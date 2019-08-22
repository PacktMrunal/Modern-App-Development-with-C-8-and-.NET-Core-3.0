using System;
using System.Collections.Generic;
using System.Text;

namespace Section1Video4.Exceptions
{
    public class HttpException : Exception
    {
        public int StatusCode { get; }

        public HttpException(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
