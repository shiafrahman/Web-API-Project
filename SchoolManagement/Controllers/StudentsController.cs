using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Models.DTOs;
using SchoolManagement.Service;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _repo;

        public StudentsController(IStudentRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] TblStudent requestModel)
        {
            try
            {
                var std = await _repo.CreateStudentAsync(requestModel.StudentName, requestModel.PhoneNumber, requestModel.DepartmentId, requestModel.Address);
                return CreatedAtAction("GetStudent", new { id = std.StudentId }, std);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(long id, [FromBody] TblStudent requestModel)
        {
            try
            {
                var std = await _repo.UpdateStudentAsync(id, requestModel.StudentName, requestModel.PhoneNumber, requestModel.DepartmentId, requestModel.Address);
                if (std == null)
                {
                    return NotFound();
                }

                return Ok(std);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(long id)
        {
            var std = await _repo.GetStudentByIdAsync
                (id);

            if (std == null)
            {
                return NotFound();
            }

            return Ok(std);
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetAllStudent()
        {
            var std = await _repo.GetAllStudentAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            try
            {
                await _repo.DeleteDeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
