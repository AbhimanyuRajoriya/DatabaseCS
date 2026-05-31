using DatabaseTutorials.DTO;
using DatabaseTutorials.Repository;
using DatabaseTutorials.Entities;
namespace DatabaseTutorials.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public List<StudentResponseDTO> GetStudents()
        {
            return _repository.GetStudents();
        }

        public void AddStudent(StudentDTO dto)
        {
            Student student = new Student()
            {
                Name = dto.Name,
                DepartmentId = dto.DepartmentId
            };

            _repository.AddStudent(student);
        }
    }
}