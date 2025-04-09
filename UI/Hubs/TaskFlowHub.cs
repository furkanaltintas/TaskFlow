using Microsoft.AspNetCore.SignalR;

namespace UI.Hubs;

public class TaskFlowHub : Hub
{
    public async Task SendTask(object task)
    {
        await Clients.All.SendAsync("ReceiveTask", task);
    }
}