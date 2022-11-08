using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class EmployeeRepositories : IRepository<Employee>
    /* 
        Inherit interface disini diikuti parameter karena di interfacenya sendiri ada parameter entity dan key
        Division >> Entity untuk Division
        int >> tipe data primary key di division itu int
    */
    {
        // Constractor dr MyCotext
        private readonly MyContext _context;
        public EmployeeRepositories(MyContext context)
        {
            _context = context;
        }

        // Get All
        public IEnumerable<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        // Get by Id
        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        // Create
        public int Create(Employee employee)
        {
            _context.Employees.Add(employee);
            var result = _context.SaveChanges();
            return result;
        }

        // Update
        public int Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }

        // Delete
        public int Delete(int id)
        {
            var data = _context.Employees.Find(id);
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
