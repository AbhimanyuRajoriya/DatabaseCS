using DatabaseTutorials.DTO;
using DatabaseTutorials.Entities;

namespace DatabaseTutorials.Repository
{
    public interface IDepartmentRepository
    {
        List<DepartmentResponseDTO> GetDepartments();

        void AddDepartment(Department department);
    }
}