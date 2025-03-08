namespace Bank2Solution.Infrastructure.Converters
{
    internal static class InputConverter<T>
    {
        public static T Convert(string value)
        {
            try
            {
                return (T)System.Convert.ChangeType(value, typeof(T));
            }
            catch 
            {
                throw new ArgumentException($"Cannot convert value to type {typeof(T).Name}");
            }
        }
    }
}
