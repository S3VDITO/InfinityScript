using System;

namespace InfinityScript
{
    public class ConsoleLogListener : ILogListener
    {
        public void LogMessage(string source, string message, LogLevel level) =>
            Console.WriteLine(string.Format("{0} - {2}",
                source == string.Empty ? string.Empty : ("[" + source + "]"), 
                level.ToString().ToUpper(),
                message));

        public bool WantsFilteredMessages { get; } = true;
    }
}
