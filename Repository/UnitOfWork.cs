using DesignPatterns.Models.Entities;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private VideoGameAppContext _context;
        private IRepository<Videogame> _videogames;
        private IRepository<Company> _companies;

        public UnitOfWork(VideoGameAppContext context)
        {
            _context = context;
        }

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
                _companies ??= new Repository<Company>(_context);
                return _companies;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
