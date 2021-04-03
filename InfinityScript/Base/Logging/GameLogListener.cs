namespace InfinityScript
{
    public class GameLogListener : ILogListener
    {
        public bool WantsFilteredMessages { get; } = true;

        public void LogMessage(string source, string message, LogLevel level) => GameInterface.Print($"[{source}] {message}\n");
    }
}
