using DesignPatterns.Models.Entities;
using DesignPatterns.MVC.Models.ViewModels;
using Repository;

namespace DesignPatterns.MVC.Strategies
{
    public class VideoGameStrategy : IVideoGameStrategy
    {
        public void Add(AddVideoGameViewModel add, IUnitOfWork unitOfWork)
        {
            var videoGame = new Videogame()
            {
                Nombre = add.Nombre,
                Genero = add.Genero,
                CompanyId = add.CompanyId,
            };

            unitOfWork.Videogames.Add(videoGame);

            unitOfWork.Save();
        }
    }
}
