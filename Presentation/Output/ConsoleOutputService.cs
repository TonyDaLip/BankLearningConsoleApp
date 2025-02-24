using Bank2Solution.Presentation.Interfaces;

namespace Bank2Solution.Presentation.Output
{
    internal class ConsoleOutputService : IOutputService
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
