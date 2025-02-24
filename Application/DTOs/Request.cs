using Bank2Solution.Infrastructure.Converters;

namespace Bank2Solution.Application.DTOs
{
    internal class Request
    {
        public Request(object command, object[] values)
        {
            Command = InputConverter<string>.Convert(command);
            Values = values;
        }

        public string Command { get; set; }
        public object[] Values { get; set; }

        public bool IsIncorrectValuesCount(int correct)
        {
            return Values.Length != correct;
        }
    }
}