using DesignPatterns.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository
{
    public class VideoGameRepository : IVideoGameRepository
    {
        private VideoGameAppContext _context;

        public VideoGameRepository(VideoGameAppContext context)
        {
            _context = context;
        }

        public void Add(Videogame videoGame) => _context.Add(videoGame);

        public void Delete(int id)
        {
            var videoGame = _context.Videogames.Find(id);
            _context.Videogames.Remove(videoGame);
        }

        public IEnumerable<Videogame> Get() => _context.Videogames.ToList();

        public Videogame Get(int id) => _context.Videogames.Find(id);

        public void Update(Videogame videoGame)
        {
            _context.Entry(videoGame).State = EntityState.Modified;

        }
        public void Save() => _context.SaveChanges();


    }

}
