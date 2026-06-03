using System.ComponentModel.DataAnnotations;
namespace DatabaseTutorials.Modules.Students.DTOs
{
    public class StudentDTO
    {
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters.")]
        [Required]
        public string? Name { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 20 characters.")]
        [Required]
        public string Username { get; set; } = string.Empty;
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 256 characters.")]
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Department ID is required.")]
        public int DepartmentId { get; set; }
    }
}