namespace PhoneGuideReportService.Application.Abstractions.Services.MessageQueue
{
    public interface IMessageQueueService
    {
        void SendMessage<TMessage>(TMessage message, string queueName) where TMessage : class;
    }
}
