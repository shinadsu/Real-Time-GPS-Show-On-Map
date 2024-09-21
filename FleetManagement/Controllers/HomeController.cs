using System.Diagnostics;
using FleetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Maps;
using Syncfusion.EJ2;
using FleetManagementAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.SignalR; // Подключаем SignalR для работы с хабами
using Hubs; // Добавляем зависимость от нашего хаба

namespace FleetManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGPSMobileReceive _gPSMobileReceive;
        private readonly IHubContext<DeviceHub> _hubContext; // Добавляем хаб

        public HomeController(ILogger<HomeController> logger, IGPSMobileReceive gPSMobileReceive)
        {
            _logger = logger;
            _gPSMobileReceive = gPSMobileReceive;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _gPSMobileReceive.GET();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
