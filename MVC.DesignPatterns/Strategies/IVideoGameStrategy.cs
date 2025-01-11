using DesignPatterns.MVC.Models.ViewModels;
using Repository;

namespace DesignPatterns.MVC.Strategies
{
    public interface IVideoGameStrategy
    {
        public void Add(AddVideoGameViewModel add, IUnitOfWork unitOfWork);
    }
}
