using DesignPatterns.Models.Entities;
using DesignPatterns.MVC.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVC.DesignPatterns.Models;
using Repository;
using System.Diagnostics;
using Tools;

namespace MVC.DesignPatterns.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Videogame> _repository;
        private readonly IOptions<ProjectConfig> _config;
        public HomeController(
            IOptions<ProjectConfig> config,
            IRepository<Videogame> repository)
        {
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_config.Value.LogPath).Save("Index");

            IEnumerable<Videogame> list = _repository.Get();

            return View("Index",list);
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
