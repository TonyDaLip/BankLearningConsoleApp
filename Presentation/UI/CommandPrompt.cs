namespace Bank2Solution.Presentation.UI
{
    internal static class CommandPrompt
    {
        public static void Display()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.WriteLine(new string(' ', Console.WindowWidth));

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.WriteLine("Type \"ShowCommands\" to see the available commands.\n");

            Console.Write("Command: ");
        }
    }
}
