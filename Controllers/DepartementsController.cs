using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private DepartementRepositories _departementRepository;
        public DepartementsController(DepartementRepositories departementRepositories)
        {
            _departementRepository = departementRepositories;
        }

        // Get All
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var data = _departementRepository.Get();
                // jika program jalan tp data tidak ada
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,       // status code jika berhasil
                        Message = "No Data"
                    });
                }

                // jika program jalan dan data ada
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,       // status code jika berhasil
                        Message = "Data Exists",
                        Data = data             // lalu ditampilkan datanya
                    });
                }
            }
            // untuk handling error agar tidak ditampilkan di tampilan
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,       // status code utk bad request
                    Message = ex.Message    // otomatis menampilkan message dr 404
                });
            }
        }

        // Get by Id
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var data = _departementRepository.GetById(id);     
                if (data == null)
                {
                    return Ok(new 
                    {
                        StatusCode = 200,
                        Message = "Data Not Found" 
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Exists",
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

        // Create
        [HttpPost]
        public ActionResult Create(Departement departement)
        {
            try
            {
                var result = _departementRepository.Create(departement);
                if (result == 0)
                {
                    return Ok(new 
                    {
                        StatusCode = 200,
                        Message = "Data Failed To Save" 
                    });
                }
                else
                {
                    return Ok(new 
                    {
                        StatusCode = 200,
                        Message = "Data Saved Successfully",
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

        // Update
        [HttpPut]
        public ActionResult Update(Departement departement)
        {
            try
            {
                var result = _departementRepository.Update(departement);
                if (result == 0)
                {
                    return Ok(new 
                    {
                        StatusCode = 200,
                        Message = "Data Failed To Update" 
                    });
                }
                else
                {
                    return Ok(new 
                    { 
                        StatusCode = 200,
                        Message = "Data Updated Successfully",
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

        // Delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _departementRepository.Delete(id);
                if (result == 0)
                {
                    return Ok(new 
                    {
                        StatusCode = 200,
                        Message = "Data Failed To Delete" 
                    });
                }
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
