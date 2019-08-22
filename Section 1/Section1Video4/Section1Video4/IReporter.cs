using System;
using System.Collections.Generic;
using System.Text;

namespace Section1Video4
{
    public enum SecurityLevel
    {
        Trace = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Critical = 4
    }

    public interface IReporter
    {
        void Report(Exception ex, string description, SecurityLevel level);
    }
}
