using Azure.Core.GeoJson;
using FleetManagementAPI.Models;

namespace FleetManagementAPI.Repositories.IRepositories
{
    public interface IGPSMobileReceive
    {
        Task<IEnumerable<DeviceLocation>> GET();
    }
}
