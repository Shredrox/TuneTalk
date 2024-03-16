﻿using Microsoft.AspNetCore.SignalR;
using TuneTalk.Core.Interfaces.IClients;

namespace TuneTalk.Infrastructure.Hubs;

public class ChatHub : Hub<IChatClient>
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.ReceiveMessage(user, message);
    }
    
    public async Task SendMessageToGroup(string sender, string receiver, string message)
    {
        await Clients.Group(receiver).ReceiveMessage(sender, message);
    } 
}