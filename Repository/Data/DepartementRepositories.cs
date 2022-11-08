using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class DepartementRepositories : IRepository<Departement>
    {
        // constractor dr my context
        private MyContext _context;
        public DepartementRepositories(MyContext context)
        {
            _context = context;
        }

        
        // Get All
        public IEnumerable<Departement> Get()
        {
            return _context.Departements.ToList();
        }

        // Get by Id
        public Departement GetById(int id)
        {
            return _context.Departements.Find(id);
        }

        // Create
        public int Create(Departement departement)
        {
            _context.Departements.Add(departement);
            var result = _context.SaveChanges();
            return result;
        }

        // Update
        public int Update(Departement departement)
        {
            _context.Entry(departement).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }

        // Delete
        public int Delete(int id)
        {
            var data = _context.Departements.Find(id);
            if (data != null)
            {
                _context.Remove(data);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }
    }
}
