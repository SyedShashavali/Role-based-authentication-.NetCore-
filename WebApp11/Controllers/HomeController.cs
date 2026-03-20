using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp11.Models;

namespace WebApp11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly webappContext webappContext;

        public HomeController(ILogger<HomeController> logger,webappContext webappContext)
        {
            _logger = logger;
            this.webappContext = webappContext;
        }

        public IActionResult Index()
        {
            return View();
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
