using Bank2Solution.Application.DTOs;

namespace Bank2Solution.Application.Processing
{
    internal class CommandParser
    {
        public Request ParseString(string input)
        {
            string[] terms = input.Split(' ');
            string[] values = terms.Skip(1).ToArray();

            return new Request(terms[0], values);
        }
    }
}
