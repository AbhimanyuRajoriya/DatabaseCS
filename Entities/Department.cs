namespace DatabaseTutorials.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public List<Student>? Students { get; set; }
    }
}
