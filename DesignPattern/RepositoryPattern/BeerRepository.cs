using System;
using DesignPattern.Data;
using DesignPattern.Models;
using Microsoft.EntityFrameworkCore;


namespace DesignPattern.RepositoryPattern
{
    public class BeerRepository : IBeerRepository
    {
       private AppDbContext _context;

        public BeerRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Beer data) => _context.Beers.Add(data);

        public void Delete(int id)
        {
            var beer  = _context.Beers.Find(id);
            _context.Beers.Remove(beer!);
        }

        public IEnumerable<Beer> Get() => _context.Beers.ToList();

        public Beer Get(int id)=> _context.Beers.Find(id)!;

        public void Update(Beer data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}


