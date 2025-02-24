using Bank2Solution.Application.DTOs;

namespace Bank2Solution.Application.Processing
{
    internal class CommandParser
    {
        public Request ParseString(string input)
        {
            object[] terms = input.Split(' ');
            object[] values = terms.Skip(1).ToArray();

            return new Request(terms[0], values);
        }
    }
}
