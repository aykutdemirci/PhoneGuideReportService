using Microsoft.AspNetCore.Mvc;
using PhoneGuide.Application.Dto.Report;
using PhoneGuideReportService.Application.Abstractions.Services;
using PhoneGuideReportService.Domain.Enums;
using System.Net;

namespace PhoneGuideReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("CreateReportRequest")]
        public async Task<IActionResult> Create()
        {
            var dtoReport = new DtoCreateReport { ReportStatus = ReportStatus.Preparing, RequestedDate = DateTime.UtcNow };

            var result = await _reportService.CreateAsync(dtoReport);

            if (result) return new StatusCodeResult((int)HttpStatusCode.Created);

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
