using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class GeneralRepository<Entity> : IRepository<Entity> where Entity : class
    {
        MyContext _context;

        public GeneralRepository(MyContext _context)
        {
            this._context = _context;
        }

        public int Create(Entity Entity)
        {
            _context.Set<Entity>().Add(Entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = GetById(id);
            _context.Set<Entity>().Remove(data);
            var result = _context.SaveChanges();
            return result;
        }

        public IEnumerable<Entity> Get()
        {
            return _context.Set<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            return _context.Set<Entity>().Find(id);
        }

        public int Update(Entity Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }
    }
}
