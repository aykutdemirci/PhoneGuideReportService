using Microsoft.Extensions.Configuration;

namespace PhoneGuideReportService.Persistance.Configurations
{
    static class ConnectionStrings
    {
        public static string PostgreSQL
        {
            get
            {
                var cfgManager = new ConfigurationManager();
                cfgManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PhoneGuideReportService.API"));
                cfgManager.AddJsonFile("appsettings.json");
                return cfgManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
