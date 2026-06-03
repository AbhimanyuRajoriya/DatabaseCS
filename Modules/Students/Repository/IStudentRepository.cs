using DatabaseTutorials.Modules.Students.DTOs;
using DatabaseTutorials.Modules.Students.Entity;

namespace DatabaseTutorials.Modules.Students.Repository
{
    public interface IStudentRepository
    {
        List<StudentResponseDTO> GetStudents();
        void AddStudent(Student student);
        Student? GetStudentByUsername(string username);
    }
}