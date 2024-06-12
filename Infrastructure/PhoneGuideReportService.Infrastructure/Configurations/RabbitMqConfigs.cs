using Microsoft.Extensions.Configuration;

namespace PhoneGuideReportService.Infrastructure.Configurations
{
    public class RabbitMqConfigs
    {
        public string HostName { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public int Port { get; set; }

        public static RabbitMqConfigs GetConfigs
        {
            get
            {
                var cfgManager = new ConfigurationManager();
                cfgManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PhoneGuideReportService.API"));
                cfgManager.AddJsonFile("appsettings.json");

                return new RabbitMqConfigs
                {
                    HostName = cfgManager.GetSection("MessageQueue:RabbitMq:HostName").Value,
                    UserName = cfgManager.GetSection("MessageQueue:RabbitMq:UserName").Value,
                    Password = cfgManager.GetSection("MessageQueue:RabbitMq:Password").Value,
                    Port = int.Parse(cfgManager.GetSection("MessageQueue:RabbitMq:Port").Value)
                };
            }
        }
    }
}
