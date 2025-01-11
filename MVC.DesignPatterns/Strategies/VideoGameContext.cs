using DesignPatterns.MVC.Models.ViewModels;
using Repository;

namespace DesignPatterns.MVC.Strategies
{
    public class VideoGameContext
    {
        private IVideoGameStrategy _strategy;

        public IVideoGameStrategy Strategy
        {
            set
            {
                _strategy = value;
            }
        }

        public VideoGameContext(IVideoGameStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Add(AddVideoGameViewModel add, IUnitOfWork unitOfWork)
        {
            _strategy.Add(add, unitOfWork);
        }
    }
}
