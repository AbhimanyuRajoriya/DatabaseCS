using DatabaseTutorials.Modules.Departments.DTOs;
namespace DatabaseTutorials.Modules.Departments.Service
{
    public interface IDepartmentService
    {
        List<DepartmentResponseDTO> GetDepartments();
        void AddDepartment(DepartmentDTO department);
    }
}
