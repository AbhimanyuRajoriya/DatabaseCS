using DatabaseTutorials.DTO;
using DatabaseTutorials.Entities;
using DatabaseTutorials.Repository;
namespace DatabaseTutorials.Service
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public List<DepartmentResponseDTO> GetDepartments()
        {
            return _repository.GetDepartments();
        }
        public void AddDepartment(DepartmentDTO dto)
        {
            Department department = new Department()
            {
                Name = dto.Name
            };
            _repository.AddDepartment(department);
        }
    }
}
