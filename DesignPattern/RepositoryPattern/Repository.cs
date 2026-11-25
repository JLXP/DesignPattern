using DesignPattern.Data;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.RepositoryPattern
{
    public class Repository<TEntyty> : IRepository<TEntyty> where TEntyty : class
    {
        private AppDbContext _context;
        private DbSet<TEntyty> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntyty>();
        }

        public void Add(TEntyty data)=>_dbSet.Add(data);

        public void Delete(int id)
        {
            var dataToDelete = _dbSet.Find(id)!;
            _dbSet.Remove(dataToDelete);
        }

        public IEnumerable<TEntyty> Get() => _dbSet.ToList();
        public TEntyty Get(int id) => _dbSet.Find(id)!;

        public void Save()=> _context.SaveChanges();

        public void Update(TEntyty data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}


