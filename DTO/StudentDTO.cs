namespace DatabaseTutorials.DTO
{
    public class StudentDTO
    {
        public string? Name { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}