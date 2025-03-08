namespace Bank2Solution.Infrastructure.Converters
{
    internal static class EnumConverter
    {
        public static TEnum TryConvertEnum<TEnum>(object value) where TEnum : struct, Enum
        {
            try
            {
                if (Enum.TryParse(typeof(TEnum), value.ToString(), true, out var result) && result is TEnum enumValue)
                {
                    return enumValue;
                }

                throw new ArgumentException($"Value {value} is not a valid {typeof(TEnum).Name}");
            }
            catch
            {
                throw new ArgumentException($"Failed to convert value '{value}' to {typeof(TEnum).Name}", nameof(value));
            }
        }
    }
}
