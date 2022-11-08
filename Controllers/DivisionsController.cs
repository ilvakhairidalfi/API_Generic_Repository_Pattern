using System.Data;
using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : BaseController<DivisionRepositories, Division>
    {
        DivisionRepositories repository;
        public DivisionsController(DivisionRepositories repository) : base(repository)
        {
            this.repository = repository;   
        }
    }
}
