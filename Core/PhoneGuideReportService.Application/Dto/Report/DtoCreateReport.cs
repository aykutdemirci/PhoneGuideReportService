using PhoneGuideReportService.Domain.Enums;

namespace PhoneGuideReportService.Application.Dto.Report
{
    public class DtoCreateReport
    {
        public DateTime RequestedDate { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}
