namespace InfinityScript
{
    using System;

    public class ConsoleLogListener : ILogListener
    {
        public bool WantsFilteredMessages { get; } = true;

        public void LogMessage(string source, string message, LogLevel level) =>
            Console.WriteLine($"{(source == string.Empty ? string.Empty : $"[{source}]")} - {message}");
    }
}
