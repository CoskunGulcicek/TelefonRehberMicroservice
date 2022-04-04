using Microsoft.AspNetCore.SignalR;
using Report.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.WebApi.Hubs.Business
{
    public class ReportHubManager
    {
        private readonly IHubContext<ReportHub> _hubContext;
        public ReportHubManager(IHubContext<ReportHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }

        public async Task SendReportsAsync(Reports reports)
        {
            await _hubContext.Clients.All.SendAsync("takeReports", reports);
        }
    }
}
