using Bank2Solution.Presentation.Interfaces;

namespace Bank2Solution.Presentation.Input
{
    internal class ConsoleCommandInput : ICommandInput
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}