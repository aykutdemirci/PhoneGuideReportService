using PhoneGuideReportService.Domain.Enums;

namespace PhoneGuideReportService.Application.Dto
{
    public class DtoReport
    {
        public Guid Id { get; set; }

        public DateTime RequestedDate { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}
