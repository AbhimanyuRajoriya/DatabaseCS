using DatabaseTutorials.Modules.Departments.Entity;

namespace DatabaseTutorials.Modules.Students.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "User";
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}