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

    public class DepartementsController : BaseController<DepartementRepositories, Departement>
    {
        DepartementRepositories repository;
        public DepartementsController(DepartementRepositories repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
