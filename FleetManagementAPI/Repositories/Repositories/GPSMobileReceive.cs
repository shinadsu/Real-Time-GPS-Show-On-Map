using Azure.Core.GeoJson;
using Backend.Data;
using FleetManagementAPI.Models;
using FleetManagementAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FleetManagementAPI.Repositories.Repositories
{
    public class GPSMobileReceive : IGPSMobileReceive
    {
        private readonly DataContext _dataContext;

        public GPSMobileReceive(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<DeviceLocation>> GET()
        {
            return await _dataContext.DeviceLocations.AsNoTracking().ToListAsync();
        }
    }
}
