using API.Models;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository, Entity> : ControllerBase
        where Repository : class, IRepository<Entity>
        where Entity : class
    {
        Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = repository.Get();
                // jika program jalan tp data tidak ada
                if (data == null)
                {
                    return Ok(new { StatusCode = 200, Message = "No Data" });
                }

                // jika program jalan dan data ada
                else
                {
                    return Ok(new { StatusCode = 200, Message = "Data Exists", Data = data });
                }
            }
            // untuk handling error agar tidak ditampilkan di tampilan
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = repository.GetById(id);     // di get dulu id nya
                // data tdk ada
                if (data == null)
                {
                    return Ok(new { Status = 200, Message = "Data Not Found" });
                }
                // data ada
                else
                {
                    return Ok(new { Status = 200, Message = "Data Found", Data = data });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Create(Entity entity)
        {
            try
            {
                var data = repository.Create(entity);
                // data di input    
                if (data != 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Saved Successfully",
                        Data = data
                    });
                }
                // data tdk di input
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Failed To Save",
                    });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        public IActionResult Update(Entity entity)
        {
            try
            {
                var data = repository.Update(entity);
                // data tdk ada
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Failed To Update"
                    });
                }
                // data ada
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Updated Successfully",
                        Data = data
                    });
                }
            }

            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = repository.Delete(id);
                // data tdk ada
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Failed To Delete"
                    });
                }
                // data ada
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Deleted Successfully",
                        Data = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}
