using DatabaseTutorials.Modules.Departments.DTOs;
using DatabaseTutorials.Modules.Departments.Entity;

namespace DatabaseTutorials.Modules.Departments.Repository
{
    public interface IDepartmentRepository
    {
        List<DepartmentResponseDTO> GetDepartments();

        void AddDepartment(Department department);
        bool DepartmentExists(int DepartmentId);
        bool DepartmentExistsByName(string name);
    }
}