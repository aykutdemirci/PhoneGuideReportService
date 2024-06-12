using Microsoft.Extensions.Configuration;

namespace PhoneGuideReportService.Infrastructure.Configurations
{
    public class RabbitMqConfigs
    {
        public string HostName { get; private set; }

        public static RabbitMqConfigs GetConfigs
        {
            get
            {
                var cfgManager = new ConfigurationManager();
                cfgManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PhoneGuideReportService.API"));
                cfgManager.AddJsonFile("appsettings.json");

                return new RabbitMqConfigs
                {
                    HostName = cfgManager.GetSection("MessageQueue:RabbitMq:HostName").Value
                };
            }
        }
    }
}
