using System;

namespace InfinityScript
{
    public class ConsoleLogListener : ILogListener
    {
        public void LogMessage(string source, string message, LogLevel level) =>
            Console.WriteLine($"{(source == string.Empty ? string.Empty : ($"[{source}]"))} - {message}");

        public bool WantsFilteredMessages { get; } = true;
    }
}
