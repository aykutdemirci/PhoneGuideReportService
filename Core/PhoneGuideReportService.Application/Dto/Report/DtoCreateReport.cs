﻿using PhoneGuideReportService.Domain.Enums;

namespace PhoneGuide.Application.Dto.Report
{
    public class DtoCreateReport
    {
        public DateTime RequestedDate { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}
