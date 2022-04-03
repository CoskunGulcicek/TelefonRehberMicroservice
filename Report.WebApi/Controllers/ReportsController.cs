using Contact.Shared.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Report.WebApi.Services;
using System;
using System.Threading.Tasks;

namespace Report.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvicer;
        private readonly IReportService _reportService;
        public ReportsController(ISendEndpointProvider sendEndpointProvicer, IReportService reportService)
        {
            _sendEndpointProvicer = sendEndpointProvicer;
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> ReportInvite(string location)
        {
            var sendEndpoint = await _sendEndpointProvicer.GetSendEndpoint(new Uri("queue:create-report-service"));
            CreateReportMessageCommand createReportMessageCommand = new ();
            createReportMessageCommand.Location = location;
            createReportMessageCommand.CreatedTime = DateTime.Now;
            await sendEndpoint.Send<CreateReportMessageCommand>(createReportMessageCommand);
            return Created("",createReportMessageCommand);
        }
    }
}
