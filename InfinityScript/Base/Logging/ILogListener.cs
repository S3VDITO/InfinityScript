namespace InfinityScript
{
    public interface ILogListener
    {
         void LogMessage(string source, string message, LogLevel level);

         bool WantsFilteredMessages { get; }
    }
}
