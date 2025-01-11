using DesignPatterns.Models.Entities;
using DesignPatterns.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace DesignPatterns.MVC.Controllers
{
    public class VideoGameController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideoGameController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<VideoGameViewModel> videogames = from v in _unitOfWork.Videogames.Get()
                                                         select new VideoGameViewModel
                                                         {
                                                             Id = v.Id,
                                                             Nombre = v.Nombre,
                                                             Genero = v.Genero
                                                         };


            return View("Index",videogames);
        }

        [HttpGet]
        public IActionResult Add()
        {
            FillComboCompany();
            return View();
        }    

        [HttpPost]
        public IActionResult Add(AddVideoGameViewModel add)
        {
            if (!ModelState.IsValid)
            {
                FillComboCompany();
                return View("Add", add);
            }

            var videoGame = new Videogame()
            {
                Nombre = add.Nombre,
                Genero = add.Genero,
            };

            if(add.CompanyId == null)
            {
                var company = new Company()
                {
                    Uid = Guid.NewGuid(),
                    Name = add.CompanyName
                };
                videoGame.CompanyId = company.Uid;
                _unitOfWork.Commpanies.Add(company);
            }
            else
            {
                videoGame.CompanyId = add.CompanyId;
            }
            _unitOfWork.Videogames.Add(videoGame);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        private void FillComboCompany()
        {
            var companies = _unitOfWork.Commpanies.Get();
            ViewBag.Companies = new SelectList(companies, "Uid", "Name");
        }
    }
}
