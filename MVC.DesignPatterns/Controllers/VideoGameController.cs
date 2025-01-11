using DesignPatterns.Models.Entities;
using DesignPatterns.MVC.Models.ViewModels;
using DesignPatterns.MVC.Strategies;
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


            return View("Index", videogames);
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

            var context = add.CompanyId is null ?
                            new VideoGameContext(new VideoGameNewCompanyStrategy()) :
                            new VideoGameContext(new VideoGameStrategy());
            context.Add(add, _unitOfWork);

            return RedirectToAction("Index");
        }

        private void FillComboCompany()
        {
            var companies = _unitOfWork.Commpanies.Get();
            ViewBag.Companies = new SelectList(companies, "Uid", "Name");
        }
    }
}
