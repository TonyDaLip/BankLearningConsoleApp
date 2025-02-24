namespace Bank2Solution.Application.DTOs
{
    internal class CommandParameters
    {
        public CommandParameters(string name, Type type, params string[] possibleValues)
        {
            Name = name;
            Type = type;
            PossibleValues = possibleValues;
        }

        public string Name { get; }
        public Type Type { get; }
        public string[] PossibleValues { get; }
    }
}
