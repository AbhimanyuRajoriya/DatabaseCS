using DatabaseTutorials.DTO;
using DatabaseTutorials.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTutorials.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetDepartments()
        {
            return Ok(_service.GetDepartments());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddDepartment(DepartmentDTO dto)
        {
            _service.AddDepartment(dto);

            return Ok("Department Added");
        }
    }
}