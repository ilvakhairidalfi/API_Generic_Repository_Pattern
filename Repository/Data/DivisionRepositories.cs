using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class DivisionRepositories : IRepository<Division, int>
        /* 
            Inherit interface disini diikuti parameter karena di interfacenya sendiri ada parameter entity dan key
            Division >> Entity untuk Division
            int >> tipe data primary key di division itu int
        */
    {
        // Constractor dr MyCotext
        private readonly MyContext _context;
        public DivisionRepositories(MyContext context)
        {
            _context = context;
        }

        // Get All
        public IEnumerable<Division> Get()
        {
            return _context.Divisions.ToList();
        }

        // Get by Id
        public Division GetById(int id)
        {
            return _context.Divisions.Find(id);
        }

        // Create
        public int Create(Division division)
        {
            _context.Divisions.Add(division);
            var result = _context.SaveChanges();
            return result;
        }

        // Update
        public int Update(Division division)
        {
            _context.Entry(division).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }

        // Delete
        public int Delete(int id)
        {
            var data = _context.Divisions.Find(id);
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
