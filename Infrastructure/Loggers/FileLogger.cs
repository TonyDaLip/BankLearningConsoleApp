using Bank2Solution.Infrastructure.Interfaces;

namespace Bank2Solution.Infrastructure.Loggers
{
    internal class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath = "log.txt")
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}
