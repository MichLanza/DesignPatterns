using DesignPatterns.MVC.Config;
using DesignPatterns.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Tools;

namespace DesignPatterns.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ProjectConfig> _config;
        public HomeController(IOptions<ProjectConfig> config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_config.Value.LogPath).Save("Index");
            return View();
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.LogPath).Save("Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
