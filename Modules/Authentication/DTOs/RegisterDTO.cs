using System.ComponentModel.DataAnnotations;
namespace DatabaseTutorials.Modules.Authentication.DTOs
{
    public class RegisterDTO
    {
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 20 characters.")]
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; } = string.Empty;
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 256 characters.")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters.")]
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Department ID is required.")]
        [Range(1, 100, ErrorMessage = "Department ID must be a positive integer.")]
        public int DepartmentId { get; set; }
    }
}