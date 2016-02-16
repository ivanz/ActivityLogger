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

        // From NLog's LogManager code
        private static string GetClassFullName()
        {
            string className;
            Type declaringType;
            var framesToSkip = 2;

            do
            {
                var frame = new StackFrame(framesToSkip, false);
                var method = frame.GetMethod();
                declaringType = method.DeclaringType;
                if (declaringType == null)
                {
                    className = method.Name;
                    break;
                }

                framesToSkip++;
                className = declaringType.FullName;
            } while (declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase));

            return className;
        }

    }
}
