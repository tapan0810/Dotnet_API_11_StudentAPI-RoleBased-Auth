using Dotnet_API_11_.Dtos.StudentDto;
using Dotnet_API_11_.Services.StudentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API_11_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        [HttpGet("GetAllStudents")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetAllStudents>>> GetAllStudents()
        {
            var result = await studentService.GetAllStudentsAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetStudentByIdDto?>> GetStudentById(int id)
        {
            var result = await studentService.GetStudentByIdAsync(id);
            if (result is null)
                return BadRequest($"Student with this ID{id} not available");

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<GetStudentByIdDto?>> CreateStudent(CreateStudentDto student)
        {
            if (student is null)
                return BadRequest("Invalid Student!");

            var stud = await studentService.CreateStudentAsync(student);

            if (stud is null)
                return BadRequest("Student Creation Failed!");

            return CreatedAtAction(nameof(GetStudentByIdDto),new {id=stud.Id},stud);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> DeleteStudentById(int id)
        {
            var stud = await studentService.DeleteStudentAsync(id);

            if (!stud)
                return BadRequest("Student with this id not available");

            return NoContent();
        }

    }
}
