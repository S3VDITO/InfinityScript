namespace InfinityScript
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    public static class Log
    {
        private static List<ILogListener> _listeners;
        private static LogLevel _filter;

        public static void Initialize(LogLevel filter)
        {
            _listeners = new List<ILogListener>();
            _filter = filter;
        }

        public static void AddListener(ILogListener listener) =>
            _listeners.Add(listener);

        public static void Debug(string message) =>
            Write(LogLevel.Debug, message);

        public static void Debug(string format, params object[] args) =>
            Debug(string.Format(format, args));

        public static void Info(string message) =>
            Write(LogLevel.Info, message);

        public static void Info(string format, params object[] args) =>
            Info(string.Format(format, args));

        public static void Error(string message) =>
            Write(LogLevel.Error, message);

        public static void Error(Exception e) =>
            Error(e.ToString());

        public static void Error(string format, params object[] args) =>
            Error(string.Format(format, args));

        public static void Write(LogLevel level, string message, params object[] args) =>
            Write(level, string.Format(message, args));

        public static void Write(LogLevel level, string message)
        {
            string source = GetSource();
            bool flag = IsLevelAllowed(level);

            foreach (ILogListener listener in Log._listeners)
            {
                if (!listener.WantsFilteredMessages | flag)
                {
                    listener.LogMessage(source, message, level);
                }
            }
        }

        private static bool IsLevelAllowed(LogLevel level) =>
            (_filter & level) == level;

        private static string GetSource()
        {
            foreach (StackFrame frame in new StackTrace(2).GetFrames())
            {
                MethodBase method = frame.GetMethod();
                Type declaringType = method.DeclaringType;
                if (declaringType.Assembly.GetName().Name != "System" && declaringType.Name != nameof(Log))
                {
                    string name = method.Name;
                    if (name == ".ctor")
                    {
                        name = declaringType.Name;
                    }

                    return $"{declaringType.Name}::{name}";
                }
            }

            return string.Empty;
        }
    }
}
