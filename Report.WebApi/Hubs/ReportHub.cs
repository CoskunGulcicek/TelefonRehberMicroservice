using Microsoft.AspNetCore.SignalR;
using Report.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.WebApi.Hubs
{
    public class ReportHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }

        public async Task SendReportsAsync(Reports reports)
        {
            await Clients.All.SendAsync("takeReports", reports);
        }
    }
}
