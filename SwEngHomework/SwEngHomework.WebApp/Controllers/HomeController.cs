using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SwEngHomework.WebApp.Models;
using System.Diagnostics;
using System.Globalization;

namespace SwEngHomework.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TimeSpan utcTime = DateTime.Now.TimeOfDay;
            ViewBag.utcTime = utcTime;
            ViewBag.Minutes = utcTime.Minutes;
            return View();
        }

        [Route("/home/privacy")]
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
