using DatabaseTutorials.Modules.Students.DTOs;
using DatabaseTutorials.Modules.Students.Entity;

namespace DatabaseTutorials.Modules.Students.Services.Repositories
{
    public interface IStudentRepository
    {
        List<StudentResponseDTO> GetStudents();
        void AddStudent(Student student);
        Student? GetStudentByUsername(string username);
    }
}