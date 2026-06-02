using DatabaseTutorials.DTO;
using DatabaseTutorials.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTutorials.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent(StudentDTO dto)
        {
            _service.AddStudent(dto);

            return Ok("Student Added");
        }
    }
}