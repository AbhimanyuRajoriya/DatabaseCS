using DatabaseTutorials.DTO;
namespace DatabaseTutorials.Service
{
    public interface IDepartmentService
    {
        List<DepartmentResponseDTO> GetDepartments();
        void AddDepartment(DepartmentDTO department);
    }
}
