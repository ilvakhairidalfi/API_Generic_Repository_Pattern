using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private DivisionRepositories _divisionRepository;

        public DivisionsController(DivisionRepositories divisionRepositories)
        {
            _divisionRepository = divisionRepositories;
        }

        // Get All
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var data = _divisionRepository.Get();
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
                var data = _divisionRepository.GetById(id);     // di get dulu id nya
                // data tdk ada
                if (data == null)
                {
                    return Ok(new 
                    {
                        Status = 200,  
                        Message = "Data Not Found" 
                    });
                }
                // data ada
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data Found",
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
        public ActionResult Create(Division division)
        {
            try
            {
                var result = _divisionRepository.Create(division);
                // data di input    
                if (result != 0)
                {
                    return Ok(new
                    { 
                        StatusCode = 200,
                        Message = "Data Saved Successfully",
                        Data = result
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

        // Update
        [HttpPut]
        public ActionResult Update(Division division)
        {
            try
            {
                var result = _divisionRepository.Update(division);
                // data tdk ada
                if (result == 0)
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
                        Message = "Data Updated Successfully" ,
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
                var result = _divisionRepository.Delete(id);
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
