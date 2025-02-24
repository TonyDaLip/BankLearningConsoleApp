using Bank2Solution.Presentation.Interfaces;

namespace Bank2Solution.Presentation.Output
{
    internal class ConsoleInfoDisplay : IInfoDisplay
    {
        private readonly Dictionary<string, (int x, int y)> _layouts = new Dictionary<string, (int x, int y)>();

        public ConsoleInfoDisplay()
        {
            _layouts["Clients"] = (0, 6);
            _layouts["Notifications"] = (Console.WindowWidth / 2 - 7, 6);
            _layouts["Commands"] = (2, 2);
        }

        public void DisplayList(string section, IEnumerable<string> listToDisplay)
        {
            if (!_layouts.TryGetValue(section, out var position))
                position = (0, Console.CursorTop);

            Console.SetCursorPosition(position.x, position.y);

            foreach (var element in listToDisplay)
            {
                Console.WriteLine(element);
                Console.SetCursorPosition(position.x, Console.CursorTop);
            }
        }
    }
}
