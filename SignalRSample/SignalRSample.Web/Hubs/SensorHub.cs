// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Core.Models;

namespace SignalRSample.Web.Hubs
{
    public class SensorHub : Hub
    {
        public Task Broadcast(string sender, Measurement measurement)
        {
            return Clients
                // Do not Broadcast to Caller:
                .AllExcept(new [] { Context.ConnectionId })
                // Broadcast to all connected clients:
                .InvokeAsync("Broadcast", sender, measurement);
        }
    }
}
