namespace InfinityScript
{
    public interface ILogListener
    {
        bool WantsFilteredMessages { get; }

        void LogMessage(string source, string message, LogLevel level);
    }
}
