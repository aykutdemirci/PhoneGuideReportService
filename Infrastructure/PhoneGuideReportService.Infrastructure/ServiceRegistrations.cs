using Microsoft.Extensions.DependencyInjection;
using PhoneGuideReportService.Application.Abstractions.Services.MessageQueue;
using PhoneGuideReportService.Infrastructure.Configurations;
using PhoneGuideReportService.Infrastructure.Services.MessageQueue.RabbitMq;
using RabbitMQ.Client;

namespace PhoneGuideReportService.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void AddMessageQueueService<T>(this IServiceCollection services) where T : class, IMessageQueueService
        {
            if (typeof(T) == typeof(RabbitMqService))
            {
                services.AddSingleton<IAsyncConnectionFactory>(provider =>
                {
                    return new ConnectionFactory { HostName = RabbitMqConfigs.GetConfigs.HostName };
                });
            }

            services.AddScoped<IMessageQueueService, T>();
        }
    }
}
