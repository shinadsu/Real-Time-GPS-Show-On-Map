using FleetManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.SignalR;

namespace Hubs
{
    public class DeviceHub : Hub
    {
        private readonly IGPSMobileReceive _gPSMobileReceive;

        public DeviceHub(IGPSMobileReceive gPSMobileReceive)
        {
            _gPSMobileReceive = gPSMobileReceive;
        }

        public async Task SendGPsDataFromDatabase()
        {
            var gpsData = await _gPSMobileReceive.GET();
            await Clients.All.SendAsync("ReceivedGPSdata", gpsData);
        }
    }
}

