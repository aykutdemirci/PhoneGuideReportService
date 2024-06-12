using PhoneGuideReportService.Application.Abstractions.Services.MessageQueue;
using PhoneGuideReportService.Infrastructure.Extensions;
using RabbitMQ.Client;
using System.Text;

namespace PhoneGuideReportService.Infrastructure.Services.MessageQueue.RabbitMq
{
    public class RabbitMqService : IMessageQueueService
    {
        private readonly IAsyncConnectionFactory _factory;

        private readonly IModel channel;

        public RabbitMqService(IAsyncConnectionFactory factory)
        {
            _factory = factory;

            var connection = _factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public void SendMessage<TMessage>(TMessage message, string queueName) where TMessage : class
        {
            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message.ToJson());

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
