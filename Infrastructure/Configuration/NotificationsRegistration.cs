using Bank2Solution.Application.Events;
using Bank2Solution.Application.Services;
using Bank2Solution.Infrastructure.Interfaces;
using Bank2Solution.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bank2Solution.Infrastructure.Configuration
{
    internal static class NotificationsRegistration
    {
        public static IServiceCollection AddNotificationServices(this IServiceCollection services)
        {
            services.AddSingleton<NotificationService>();

            services.AddSingleton<IEventAggregator>(provider =>
            {
                var eventAggregator = new EventAggregator();
                var notificationService = provider.GetRequiredService<NotificationService>();

                eventAggregator.Subscribe<AccountOpenedEvent>(notificationService.OnAccountOpened);
                eventAggregator.Subscribe<AccountClosedEvent>(notificationService.OnAccountClosed);
                eventAggregator.Subscribe<NewClientAddedEvent>(notificationService.OnNewClientAdded);
                eventAggregator.Subscribe<OperationProceededEvent>(notificationService.OnOperationProceeded);

                return eventAggregator;
            });

            return services;
        }
    }
}
