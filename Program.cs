using Bank2Solution.Application.Presentation;
using Bank2Solution.Application.Processing;
using Bank2Solution.Application.Services;
using Bank2Solution.Infrastructure.Configuration;
using Bank2Solution.Presentation.Interfaces;
using Bank2Solution.Presentation.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Bank2Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var bank = serviceProvider.GetService<BankService>();
            var commandInput = serviceProvider.GetService<ICommandInput>();
            var commandHandler = serviceProvider.GetService<CommandHandler>();
            var ui = serviceProvider.GetService<ConsoleLayout>();
            var timer = serviceProvider.GetService<TimeManager>();

            timer.OnTimeAdvanced += months => bank.AdvanceTime(months);
            timer.StartSimulation(6);

            string welcomingPhrase = "Welcome to the best bank NAEbank!";

            Task.Run(() =>
            {
                while (true)
                {
                    lock (Console.Out)
                    {
                        ui.DrawUI(welcomingPhrase);
                    }
                    Thread.Sleep(1000);
                }
            });

            while (true)
            {
                lock (Console.Out)
                {
                    Console.Clear();
                    CommandPrompt.Display();
                }

                var command = commandHandler.GetCommand(commandInput.ReadInput());

                lock (Console.Out)
                {
                    if (command == null)
                    {
                        Console.WriteLine("Unknown command");
                    }
                    else
                    {
                        command.Execute();
                    }
                }
            }

        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddNotificationServices();
            services.AddApplicationServices();
            services.AddInfrastructureServices();
            
            services.AddAccountFactory();
            services.AddCommandFactory();

            services.AddPresentationServices();

            return services.BuildServiceProvider();
        }
    }
}
