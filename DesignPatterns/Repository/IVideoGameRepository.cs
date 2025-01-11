
using DesignPatterns.Models;

namespace DesignPatterns.Repository
{
    public interface IVideoGameRepository
    {
        IEnumerable<Videogame> Get();
        Videogame Get(int id);
        void Add(Videogame videoGame);
        void Delete(int id);
        void Update(Videogame videoGame);
        void Save();
    }

}
