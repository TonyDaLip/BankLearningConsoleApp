using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Services;

namespace Bank2Solution.Presentation.UI
{
    internal static class StatusBar
    {
        private const int DatePositionX = 0;
        private const int DatePositionY = 0;

        private const int LogoPositionX = 0;
        private const int LogoPositionY = 1;

        private const int DepartmentLabelX = 8;
        private const int DepartmentLabelY = 4;

        private const int NotificationsLabelY = 4;

        public static void Draw(TimeManager timer, BankService bank, string logo)
        {
            Console.SetCursorPosition(DatePositionX, DatePositionY);
            Console.Write(GetDateText(timer));

            Console.SetCursorPosition(LogoPositionX, LogoPositionY);
            Console.Write(GetCenteredText(logo));

            Console.SetCursorPosition(DepartmentLabelX, DepartmentLabelY);
            Console.Write($"Department of {bank.CurrentDepartment} clients");

            Console.SetCursorPosition(Console.WindowWidth / 2, NotificationsLabelY);
            Console.Write("Notifications");
        }

        private static string GetCenteredText(string text)
        {
            return text.PadLeft((Console.WindowWidth + text.Length) /2);
        }

        private static string GetDateText(TimeManager timer)
        {
            return $"Date: {timer.CurrentTime:MM.yyyy}".PadLeft(Console.WindowWidth);
        }
    }
}
