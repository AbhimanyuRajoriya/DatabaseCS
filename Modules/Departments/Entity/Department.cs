using DatabaseTutorials.Modules.Students.Entity;

namespace DatabaseTutorials.Modules.Departments.Entity
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public List<Student>? Students { get; set; }
    }
}
