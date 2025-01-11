using DesignPatterns.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private VideoGameAppContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(VideoGameAppContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity) => _dbSet.Add(entity);

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Get() => _dbSet.ToList();

        public TEntity Get(int id) => _dbSet.Find(id);

        public void Save() => _context.SaveChanges();

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
