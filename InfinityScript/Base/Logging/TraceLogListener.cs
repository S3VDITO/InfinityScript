using System.Diagnostics;

namespace InfinityScript
{
    public class TraceLogListener : ILogListener
    {
        public void LogMessage(string source, string message, LogLevel level) =>
            Trace.WriteLine($"[{source}] {message}");

        public bool WantsFilteredMessages { get; } = false;
    }
}
