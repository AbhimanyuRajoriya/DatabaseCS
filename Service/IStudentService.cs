using DatabaseTutorials.DTO;
namespace DatabaseTutorials.Service
{
    public interface IStudentService
    {
        List<StudentResponseDTO> GetStudents();
        void AddStudent(StudentDTO student);
    }
}