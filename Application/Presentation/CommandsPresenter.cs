using Bank2Solution.Application.DTOs;
using Bank2Solution.Presentation.Interfaces;

namespace Bank2Solution.Application.Presentation
{
    internal class CommandsPresenter
    {
        private readonly IInfoDisplay _infoDisplay;
        private readonly IOutputService _outputService;

        public CommandsPresenter(IInfoDisplay infoDisplay, IOutputService outputService)
        {
            _infoDisplay = infoDisplay;
            _outputService = outputService;

        }

        public void Display(Dictionary<string, IEnumerable<CommandParameters>> commandParameters)
        {
            var commandsDescription = new List<string>();

            foreach (var commandParameter in commandParameters)
            {                
                var description = $"- {commandParameter.Key} " + string.Join(" ", 
                    commandParameter.Value.Select(des => $"[{des.Name}" +
                    $"{(des.PossibleValues.Any() ? $" ({string.Join("/", des.PossibleValues)})": "")}]"));

                commandsDescription.Add(description);
            }

            _outputService.Clear();
            _infoDisplay.DisplayList("Commands", commandsDescription);
            _outputService.ReadKey();
        }
    }
}
