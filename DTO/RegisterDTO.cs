namespace DatabaseTutorials.DTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}