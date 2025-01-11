using DesignPatterns.Models;
using DesignPatterns.Repository;

namespace DesignPatterns.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private VideoGameAppContext _context;
        public IRepository<Videogame> _videogames;
        public IRepository<Company> _commpanies;

        public IRepository<Videogame> Videogames
        {
            get
            {
                _videogames ??= new Repository<Videogame>(_context);
                return _videogames;
            }
        }

        public IRepository<Company> Commpanies
        {
            get
            {
                _commpanies ??= new Repository<Company>(_context);
                return _commpanies;
            }
        }

        public UnitOfWork(VideoGameAppContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
