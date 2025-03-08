using Bank2Solution.Infrastructure.Converters;

namespace Bank2Solution.Application.DTOs
{
    internal class Request
    {
        public Request(string command, string[] values)
        {
            Command = InputConverter<string>.Convert(command);
            Values = values;
        }

        public string Command { get; set; }
        public string[] Values { get; set; }

        public bool IsIncorrectValuesCount(int correct)
        {
            return Values.Length != correct;
        }
    }
}