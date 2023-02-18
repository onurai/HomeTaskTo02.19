using HomeTaskTo02._19.Data.Entities;
using HomeTaskTo02._19.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeTaskTo02._19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;


        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var existedStudent = await _studentService.Get(id);
            if (existedStudent == null)
            {
                return NotFound("Student was not found");
            }
            return Ok(existedStudent);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBook(Student student)
        {
            var isSuccessfullyCreated = await _studentService.Create(student);
            return Ok(isSuccessfullyCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Student student)
        {
            var isSuccessfullyUpdated = await _studentService.Update(id, student);
            return Ok(isSuccessfullyUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            await _studentService.Remove(id);
            return Ok();
        }
    }
}
