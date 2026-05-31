using DatabaseTutorials.DTO;
using DatabaseTutorials.Service;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTutorials.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_service.GetDepartments());
        }

        [HttpPost]
        public IActionResult AddDepartment(DepartmentDTO dto)
        {
            _service.AddDepartment(dto);

            return Ok("Department Added");
        }
    }
}