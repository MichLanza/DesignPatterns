using DesignPatterns.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
        public IRepository<Videogame> Videogames { get; }
        public IRepository<Company> Commpanies { get; }
        public void Save();
    }
}
