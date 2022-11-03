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
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,       // status code utk bad request
                    Message = ex.Message    // otomatis menampilkan message dr 404
                });
            }



        }
    }
}
