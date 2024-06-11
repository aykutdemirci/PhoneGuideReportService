using PhoneGuideReportService.Domain.Entities.Common;
using PhoneGuideReportService.Domain.Enums;

namespace PhoneGuideReportService.Domain.Entities
{
    public class Report : BaseEntity
    {
        public DateTime RequestedDate { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}
