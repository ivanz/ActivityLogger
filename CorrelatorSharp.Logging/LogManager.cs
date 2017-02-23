using System;
using System.Diagnostics;
using System.Reflection;

namespace CorrelatorSharp.Logging
{
    public static class LogManager
    {
        public static ILogger GetCurrentClassLogger()
        {
            StackFrame frame = new StackFrame(1, false);
            return LoggingConfiguration.LogManager.GetLogger(frame.GetMethod().DeclaringType.FullName);
        }

        public static ILogger GetLogger(string name)
        {
            return LoggingConfiguration.LogManager.GetLogger(name);
        }
    }
}
