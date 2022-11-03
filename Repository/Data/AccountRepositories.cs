using System.ComponentModel.DataAnnotations;
using API.Context;
using API.Handler;
using API.View_Model;

namespace API.Repository.Data
{
    public class AccountRepositories
    {
        private readonly MyContext _context;
        public AccountRepositories(MyContext context)
        {
            _context = context;
        }

        // Login
        public int Login(LoginVM loginVM)
        {
            var account = _context.Logins.Select(a => new
            {
                Email = a.Email,
                Password = a.Password
            }).SingleOrDefault(x => x.Email == loginVM.Email);

            // kalau ada baru panggil validatepassword(password. data.password)
            // var result = Hashing.ValidatePassword(loginVM.Password);
            if (account != null)
            {

            }
        }
        // Register

        // Change Password

        // Forgot Password
    }
}
