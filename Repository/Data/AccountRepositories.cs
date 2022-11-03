using System.ComponentModel.DataAnnotations;
using API.Context;
using API.Handler;
using API.Models;
using API.View_Model;
using Microsoft.AspNetCore.Mvc;

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
        public ResponseLoginVM Login(LoginVM loginVM)
        {
            ResponseLoginVM resp = new ResponseLoginVM();
            var checkEmail = _context.Employees
              .Where(e => e.Email == loginVM.Email).SingleOrDefault();
            if (checkEmail == null)
            {
                return resp;
            }
            else
            {
                var checkPw = _context.Users.Where(u => u.Id == checkEmail.Id).SingleOrDefault();
                if (checkPw == null)
                {
                    return resp;
                }
                else
                {
                    var result = Hashing.ValidatePassword(loginVM.Password, checkPw.Password);
                    if (result)
                    {
                        var outRole = _context.Roles
                        .Where(r => r.Id == checkPw.Id).SingleOrDefault();

                        resp.Id = checkEmail.Id;
                        resp.FullName = checkEmail.FullName;
                        resp.Email = checkEmail.Email;
                        resp.Role = outRole.Name;
                        return resp;
                    }
                    else
                    {
                        return resp;
                    }
                }
            }
        }
        // Register
        public int Register(string fullName, string email, DateTime birthDate, string password)
        {
            Employee employee = new Employee()
            {
                FullName = fullName,
                Email = email,
                BirthDate = birthDate
            };

            // cek email tdk blh sama
            var checkEmail = _context.Employees
                .Where(x => x.Email.Equals(email)).SingleOrDefault();
            if (checkEmail != null)
            {
                return 1;
            }
            else
            {
                _context.Employees.Add(employee);

                var result = _context.SaveChanges();
                if (result > 0)
                {
                    var id = _context.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                    User user = new User
                    {
                        Id = id,
                        Password = Hashing.HashPassword(password),
                        RoleId = 1
                    };
                    _context.Users.Add(user);
                    var resultUser = _context.SaveChanges();
                    if (resultUser > 0)
                    {
                        return 2;
                    }
                }
                return 0;
            }
        }

        // Change Password

        // Forgot Password
    }
}
