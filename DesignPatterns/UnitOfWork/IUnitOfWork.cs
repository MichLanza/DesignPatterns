using DesignPatterns.Models;
using DesignPatterns.Repository;

namespace DesignPatterns.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Videogame> Videogames { get; }
        public IRepository<Company> Commpanies { get; }
        public void Save();
    }
}
