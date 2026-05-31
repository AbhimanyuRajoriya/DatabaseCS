using DatabaseTutorials.DTO;
using DatabaseTutorials.Entities;

namespace DatabaseTutorials.Repository
{
    public interface IStudentRepository
    {
        List<StudentResponseDTO> GetStudents();

        void AddStudent(Student student);
    }
}