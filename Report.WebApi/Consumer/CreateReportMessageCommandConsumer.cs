using Contact.Shared.Messages;
using MassTransit;
using Report.WebApi.Models;
using Report.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.WebApi.Consumer
{
    public class CreateReportMessageCommandConsumer : IConsumer<CreateReportMessageCommand>
    {
        private readonly IReportService _reportService;
        public CreateReportMessageCommandConsumer(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task Consume(ConsumeContext<CreateReportMessageCommand> context)
        {
            Reports reports = new();
            reports.CreatedTime = context.Message.CreatedTime;
            reports.FileName = "tesn";
            reports.FilePath = "testp";
            reports.Location = context.Message.Location;
            await _reportService.CreateAsync(reports);
        }

    }
}
