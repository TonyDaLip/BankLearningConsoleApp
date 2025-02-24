namespace Bank2Solution.Presentation.Interfaces
{
    internal interface IInfoDisplay
    {
        void DisplayList(string section, IEnumerable<string> listToDisplay);
    }
}
