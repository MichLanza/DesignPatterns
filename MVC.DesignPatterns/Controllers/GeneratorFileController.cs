using Microsoft.AspNetCore.Mvc;
using Repository;
using Tools.Generator;

namespace DesignPatterns.MVC.Controllers
{
    public class GeneratorFileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _builder;

        public GeneratorFileController(
            IUnitOfWork unitOfWork,
            GeneratorConcreteBuilder builder)
        {
            _unitOfWork = unitOfWork;
            _builder = builder;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateFile(int optionFile)
        {
            try
            {
                var videogames = _unitOfWork.Videogames.Get();
                var content = videogames.Select(v => v.Nombre).ToList();
                var director = new GeneratorDirector(_builder);
                string path = "file" + DateTime.Now.Ticks + new Random().Next(0, 1000) + ".txt";
                if (optionFile == 1)
                    director.GenerateJson(content, path);
                else
                    director.GeneratePipes(content, path);
                
                var generator = _builder.GetGenerator();
                
                generator.Save();

                return Json("Archivo Generado");

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
