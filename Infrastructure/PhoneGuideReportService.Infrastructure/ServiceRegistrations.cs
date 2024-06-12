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
                    var settings = RabbitMqConfigs.GetConfigs;

                    var factory = new ConnectionFactory
                    {
                        //UserName = settings.UserName,
                        //Password = settings.Password,
                        HostName = settings.HostName,
                        //Port = settings.Port,

                        //DispatchConsumersAsync = true,
                        //AutomaticRecoveryEnabled = true,
                    };

                    return factory;
                });
            }

            services.AddScoped<IMessageQueueService, T>();
        }
    }
}
