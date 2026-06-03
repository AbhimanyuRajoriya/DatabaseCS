using System.ComponentModel.DataAnnotations;
namespace DatabaseTutorials.Modules.Departments.DTOs
{
    public class DepartmentDTO
    {
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters.")]
        [Required(ErrorMessage = "Department name is required.")]
        public string? Name { get; set; }
    }
}