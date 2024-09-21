using Microsoft.EntityFrameworkCore;

namespace FleetManagementAPI.Models
{
    [Keyless]
    public class DeviceLocation
    {   
        public Guid DeviceId    { get; set; } 
        public double Latitude   { get; set; }
        public double Longitude  { get; set; }
    }
}
