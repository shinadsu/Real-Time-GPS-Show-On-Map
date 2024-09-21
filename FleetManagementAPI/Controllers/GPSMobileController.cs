using FleetManagementAPI.Models;
using FleetManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GPSMobileController : ControllerBase
    {
        private readonly IGPSMobileReceive _gPSMobileReceive;
        public GPSMobileController(IGPSMobileReceive gPSMobileReceive)  
        {
            _gPSMobileReceive = gPSMobileReceive;
        }

        [HttpGet]
        public async Task<IEnumerable<DeviceLocation>> GetMobileData()
        {
            try
            {
                return await _gPSMobileReceive.GET();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
