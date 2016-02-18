using System;
using System.Diagnostics;
using System.Reflection;

namespace CorrelatorSharp.Logging
{
    public static class LogManager
    {
        public static ILogger GetCurrentClassLogger()
        {
            var name = GetClassFullName();
            return GetLogger(name);
        }

        public static ILogger GetLogger(string name)
        {
            return LoggingConfiguration.LogManager.GetLogger(name);
        }

        private static string GetClassFullName()
        {
            var framesToSkip = 2;
            var frame = new StackFrame(framesToSkip, false);
            var method = frame.GetMethod();
            var declaryingType = method.DeclaringType;

            Console.WriteLine($"Modlue: {method.DeclaringType.Module.Name}");

            if (declaryingType == null)
                return method.Name;

            return declaryingType.FullName;
        }

    }
}
