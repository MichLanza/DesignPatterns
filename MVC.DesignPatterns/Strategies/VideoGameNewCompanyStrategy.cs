using DesignPatterns.Models.Entities;
using DesignPatterns.MVC.Models.ViewModels;
using Repository;

namespace DesignPatterns.MVC.Strategies
{
    public class VideoGameNewCompanyStrategy : IVideoGameStrategy
    {
        public void Add(AddVideoGameViewModel add, IUnitOfWork unitOfWork)
        {
            var videoGame = new Videogame()
            {
                Nombre = add.Nombre,
                Genero = add.Genero,
            };
            var company = new Company()
            {
                Uid = Guid.NewGuid(),
                Name = add.CompanyName
            };
            videoGame.CompanyId = company.Uid;
            unitOfWork.Commpanies.Add(company);
            unitOfWork.Videogames.Add(videoGame);

            unitOfWork.Save();
        }
    }
}
