// File: Controllers/StudentController.cs
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationForm.Dto;
using StudentRegistrationForm.Models;
using StudentRegistrationForm.Services;

namespace StudentRegistrationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // CREATE - POST /api/Student
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequest request)
        {
            if (request == null)
                return BadRequest("Request cannot be null.");

            try
            {
                var student = await _studentService.CreateFromDtoAsync(request);
                return CreatedAtAction(nameof(GetAll), new { id = student.StudentId }, student);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to create student", Error = ex.Message });
            }
        }

        // READ ALL - GET /api/Student
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            try
            {
                var students = await _studentService.GetByIdAsync(id);
                
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching students", Error = ex.Message });
            }
        }

        // StudentController.cs mein ye method add kar de

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, Student student)
        {
            if (id != student.StudentId)
                return BadRequest("ID mismatch");

            var existingStudent = await _studentService.GetByIdAsync(id);
            if (existingStudent == null)
                return NotFound();

            try
            {
                await _studentService.UpdateStudentAsync(student);
                return NoContent(); // 204 = Update successful
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // DEBUG - Sirf development ke liye
        [HttpPost("debug")]
        public IActionResult Debug([FromBody] CreateStudentRequest? request)
        {
            if (request == null)
                return BadRequest("No data received.");

            return Ok(new
            {
                Message = "Bhai data bilkul sahi aa raha hai!",
                AddressesCount = request.Addresses?.Count ?? 0,
                GuardiansCount = request.Guardians?.Count ?? 0,
                AcademicHistoriesCount = request.AcademicHistories?.Count ?? 0,
                HasPhoto = !string.IsNullOrEmpty(request.PhotoBase64),
                PhotoBase64_Length = request.PhotoBase64?.Length ?? 0,
                SampleData = request
            });
        }
    }
}