using API.Models;
using API.View_Model;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> context) : base(context)
        {

        }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
