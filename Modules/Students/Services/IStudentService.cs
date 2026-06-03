using DatabaseTutorials.Modules.Students.DTOs;
namespace DatabaseTutorials.Modules.Students.Services
{
    public interface IStudentService
    {
        List<StudentResponseDTO> GetStudents();
        void AddStudent(StudentDTO student);
    }
}