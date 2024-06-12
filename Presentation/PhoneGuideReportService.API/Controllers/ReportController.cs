using Microsoft.AspNetCore.Mvc;
using PhoneGuideReportService.Application.Dto.Report;
using PhoneGuideReportService.Application.Abstractions.Services;
using PhoneGuideReportService.Domain.Enums;
using System.Net;
using PhoneGuideReportService.Application.Abstractions.Services.MessageQueue;

namespace PhoneGuideReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IMessageQueueService _messageQueueProducer;

        public ReportController(IReportService reportService,
                                IMessageQueueService messageQueueProducer)
        {
            _reportService = reportService;
            _messageQueueProducer = messageQueueProducer;
        }

        [HttpPost("CreateReportRequest")]
        public async Task<IActionResult> Create()
        {
            var dtoReport = new DtoCreateReport { ReportStatus = ReportStatus.Preparing, RequestedDate = DateTime.UtcNow };

            var reportId = await _reportService.CreateAsync(dtoReport);

            if (reportId != Guid.Empty)
            {
                var report = await _reportService.GetByIdAsync(reportId);

                _messageQueueProducer.SendMessage(report, "report_queue");

                return new StatusCodeResult((int)HttpStatusCode.Created);
            }

            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("GetReportRequests")]
        public async Task<IActionResult> GetReportRequests()
        {
            var reports = await _reportService.GetAllAsync();

            return Ok(reports);
        }
    }
}
