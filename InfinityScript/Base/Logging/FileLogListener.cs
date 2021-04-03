namespace InfinityScript
{
    using System;
    using System.Globalization;
    using System.IO;

    public class FileLogListener : ILogListener
    {
        private StreamWriter _writer;

        public FileLogListener(string filename, bool append)
        {
            try
            {
                _writer = new StreamWriter(filename, append);
            }
            catch
            {
                _writer = null;
            }
        }

        public bool WantsFilteredMessages { get; } = true;

        public void LogMessage(string source, string message, LogLevel level)
        {
            if (_writer == null)
            {
                return;
            }

            _writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)} - {(source == string.Empty ? string.Empty : "[" + source + "]")} - {level.ToString().ToUpper()}: {message}");
            _writer.Flush();
        }
    }
}
