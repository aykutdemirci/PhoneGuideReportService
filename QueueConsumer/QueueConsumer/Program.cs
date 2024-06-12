using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "report_queue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Received {message}");

    //Bu aşamada raporda istenen verileri almak için bir http istek ile diğer servise gidilecek.
    //Rapor bilgileri hazırlandıktan sonra bir excel dosyaya yazılarak dosyanın url'si, PhoneGuideReportDb'deki Reports tablosuna field olarak eklenip bu field'a yazılacak
    //Raporun durumu "tamamlandı" olarak güncellenecek
    //Kullanıcı rapor raporu talep ettiğinde dosyanın url'si gönderilecek kullanıcının dosyayı indirmesi sağlanacak
};

channel.BasicConsume(queue: "report_queue",
                     autoAck: true,
                     consumer: consumer);

Console.ReadLine();
