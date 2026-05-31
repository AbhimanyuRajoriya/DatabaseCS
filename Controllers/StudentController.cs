using DatabaseTutorials.DTO;
using DatabaseTutorials.Service;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTutorials.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());
        }

        [HttpPost]
        public IActionResult AddStudent(StudentDTO dto)
        {
            _service.AddStudent(dto);

            return Ok("Student Added");
        }
    }
}