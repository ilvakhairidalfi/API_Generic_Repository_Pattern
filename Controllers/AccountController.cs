using API.View_Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using API.Repository.Data;
using API.Context;
using API.Models;
using API.Handler;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountRepositories _accountRepository;
        private MyContext _context;

        public AccountController(AccountRepositories accountRepositories)
        {
            _accountRepository = accountRepositories;
        }

        //Login
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            try
            {
                var login = _accountRepository.Login(loginVM);
                if (login.Id != 0)
                {
                    return Ok(new { StatusCode = 200, Message = "Login Success", Data = login });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        // Register
        [HttpPost("Register")]
        public ActionResult Register(string fullName, string email, DateTime birthDate, string password)
        {
            try
            {
                var regist = _accountRepository.Register(fullName, email, birthDate, password);
                if (regist == 0)
                {
                    return Ok(new { StatusCode = 201, Message = "Registration was Failed" });
                }
                else if (regist == 1)
                {
                    return Ok(new { StatusCode = 202, Message = "Email was Exists" });
                }
                else
                {
                    return Ok(new { StatusCode = 200, Message = "Registration Complete" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        // Change Password
        [HttpPut("Change Password")]
        public ActionResult ChangePassword(string email, string currentPw, string newPw)
        {
            try
            {
                var changepw = _accountRepository.ChangePassword(email, currentPw, newPw);
                if (changepw == "s")
                {
                    return Ok(new {StatusCode = 200, Message = "Change Password Success"});
                }
                else if (changepw == "f")
                {
                    return Ok(new { StatusCode = 201, Message = "Change Password Failed" });
                }
                else
                {
                    return Ok(new { StatusCode = 202, Message = "Email Not Found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        // Forgot Password
        [HttpPut("Forgot Password")]
        public ActionResult ForgotPassword(string fullName, string email, string newPw)
        {
            try
            {
                var changepw = _accountRepository.ForgotPassword(fullName,email, newPw);
                if (changepw == "s")
                {
                    return Ok(new { StatusCode = 200, Message = "Change Password Success" });
                }
                else if (changepw == "f")
                {
                    return Ok(new { StatusCode = 201, Message = "Forgot Password Failed" });
                }
                else
                {
                    return Ok(new { StatusCode = 202, Message = "Email Not Found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }
    }
}
