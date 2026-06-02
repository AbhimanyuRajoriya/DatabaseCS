using DatabaseTutorials.DTO;
using DatabaseTutorials.Repository;
using DatabaseTutorials.Entities;
using AutoMapper;
using DatabaseTutorials.Security;
namespace DatabaseTutorials.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasherService _passwordHasher;

        public StudentService(IStudentRepository repository, IMapper mapper, IPasswordHasherService passwordHasher)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public List<StudentResponseDTO> GetStudents()
        {
            return _repository.GetStudents();
        }

        public void AddStudent(StudentDTO dto)
        {
            var student = _mapper.Map<Student>(dto);
            student.PasswordHash = _passwordHasher.HashPassword(dto.Password);
            student.Role = "User";
            _repository.AddStudent(student);
        }
    }
}