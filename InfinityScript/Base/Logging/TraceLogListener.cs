namespace InfinityScript
{
    using System.Diagnostics;

    public class TraceLogListener : ILogListener
    {
        public bool WantsFilteredMessages { get; } = false;

        public void LogMessage(string source, string message, LogLevel level) =>
            Trace.WriteLine($"[{source}] {message}");
    }
}
