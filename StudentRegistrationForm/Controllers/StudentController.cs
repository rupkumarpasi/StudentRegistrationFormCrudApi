using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using StudentRegistrationForm.Models;
using StudentRegistrationForm.Models.DTOs;
using StudentRegistrationForm.Services;

namespace StudentRegistrationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET: api/student
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null) return NotFound();

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequest request)
        {
            if (request?.student == null)
                return BadRequest("Student data is required.");

            var result = await _service.CreateFromDtoAsync(request.student);
            return CreatedAtAction(nameof(Get), new { id = result.StudentId }, result);
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Student student)
        {
            var success = await _service.UpdateAsync(id, student);
            if (!success) return NotFound();

            return Ok("Updated Successfully");
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();

            return Ok("Deleted Successfully");
        }
    }
}
